using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script_Munition : MonoBehaviour
{
    [SerializeField] public int munition;
    [SerializeField] public int numOfMunition;

    [SerializeField] public Image[] bullet;
    [SerializeField] public Sprite bullet_full;
    [SerializeField] public Sprite bullet_empty;

    private float fireRate2 = 2f;

    private WaitForSeconds shotDuration2 = new WaitForSeconds(0.07f);
    private float nextFire2;

    void Update()
    {
        // bullet cannot exceed limit

        if (munition > numOfMunition)
        {
            munition = numOfMunition;
        }

        // setting sprite according to bullets

        for (int i = 0; i < bullet.Length; i++)
        {
            if (i < munition)
            {
                bullet[i].sprite = bullet_full;
            }

            else
            {
                bullet[i].sprite = bullet_empty;
            }

            if (i < numOfMunition)
            {
                bullet[i].enabled = true;
            }
            else
            {
                bullet[i].enabled = false;
            }
        }

        // attack

        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire2)
        {
            nextFire2 = Time.time + fireRate2;
            munition = munition - 1;

            StartCoroutine(ShotEffect2());
        }

        if (munition <= 0)
        {
            StartCoroutine(ShotEffect3());
            SceneManager.LoadScene("SCN_GameOver");
        }
    }

    private void Reload()
    {
        munition = munition + 1;
    }

    private IEnumerator ShotEffect2()
    {
        yield return shotDuration2;
    }

    private IEnumerator ShotEffect3()
    {
        yield return 3f;
    }

}
