using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Buttons : MonoBehaviour
{

    public GameObject Help_Button;
    [SerializeField] Animator transitionAnim;

    Script_Audio_Manager audioManager;

    public void ButtonPress2()
    {
        audioManager.PlaySFX(audioManager.SFX_YouWantToPlay);
        StartCoroutine(Delay());
        if (Help_Button.active == true)
        {
            Help_Button.SetActive(false);
        }
        else
        {
            Help_Button.SetActive(true);
        }

    }

    IEnumerator Delay()
    {  
        transitionAnim.SetTrigger("End");
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("SCN_Final Game");
        transitionAnim.SetTrigger("Start");
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Script_Audio_Manager>();
    }

    public void ButtonPress1()
    {
        SceneManager.LoadScene("SCN_Final Help");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("SCN_Main Menu");
    }
}
