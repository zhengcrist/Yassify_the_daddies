using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Script_RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;
    public float fireRate = 2f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
    private LineRenderer laserLine;
    private float nextFire;

    [SerializeField] Animator Revolver_animator;

    Script_Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }

    void Start()
    {
      laserLine = GetComponent<LineRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        gunAction();
    }

    private void gunAction()
    {
        Vector3 pos = this.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);

        var target = GameObject.Find("Revolver2");

        Cursor.visible = false;

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());
            

            Vector3 rayOrigin = target.transform.position = new Vector3(pos.x, pos.y - 100, -9);
            RaycastHit hit;


            laserLine.SetPosition(0, gunEnd.position);
            Debug.Log("Hello");

            if (Physics.Raycast(rayOrigin, target.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);

                Script_Health health = hit.collider.GetComponent<Script_Health>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (target.transform.forward * weaponRange));
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        audioManager.PlaySFX(audioManager.SFX_bullet);
        Revolver_animator.SetTrigger("Shoot");
        laserLine.enabled = true;
        yield return shotDuration;
        laserLine.enabled = false;
    }
}
