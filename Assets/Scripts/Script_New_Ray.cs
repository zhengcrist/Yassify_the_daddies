using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_New_Ray : MonoBehaviour
{
    public int gunDamage = 1;


    private float fireRate = 2f;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private float nextFire;

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
                Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                Destroy(hit.collider.gameObject);
            }
        }
    }
    private  IEnumerator ShotEffect()
    {
        audioManager.PlaySFX(audioManager.SFX_bullet);
        Revolver_animator.SetTrigger("Shoot");
        yield return shotDuration;
    }
}
