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

    Script_Audio_Manager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }

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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioManager.PlaySFX(audioManager.SFX_bullet);
            munition = munition -1;
        }
       
    if (munition <= 0)
        {
            SceneManager.LoadScene("SCN_GameOver");
        }
    }
}
