using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_StartButton : MonoBehaviour
{
    public void ButtonPress()
    {
        SceneManager.LoadScene("SCN_Final Game");
    }
}
