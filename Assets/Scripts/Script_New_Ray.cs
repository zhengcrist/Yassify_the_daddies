using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_New_Ray : MonoBehaviour
{
    public int gunDamage = 1;


    private float fireRate = 2f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

    //SpawnZone spawnZone;
    //public Script_Cible1 cible1;
    public int Score;
    [SerializeField] TextMeshProUGUI textScore;

    [SerializeField] Animator Revolver_animator;

    // Audio

    Script_Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Vector2.zero);

            if (hit.collider != null)
            {
                audioManager.PlaySFX(audioManager.SFX_Meow);
                Destroy(hit.collider.gameObject);
                //this.gameObject.GetComponent<cible1.Daddy_Arnold>().sprite = cible1.Daddy_Arnoldy;
                //spawnZone.EnnemyLess();
                Score+=100;
                Debug.Log("Score : " + Score);
                textScore.text = Score.ToString();
            }
        }
    }
    private  IEnumerator ShotEffect()
    {
        Revolver_animator.SetTrigger("Shoot");
        audioManager.PlaySFX(audioManager.SFX_bullet);
        yield return shotDuration;
    }
}
