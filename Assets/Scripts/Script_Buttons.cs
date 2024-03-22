using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_Buttons : MonoBehaviour
{
    public void ButtonPress2()
    {
        SceneManager.LoadScene("SCN_Final Game");
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
