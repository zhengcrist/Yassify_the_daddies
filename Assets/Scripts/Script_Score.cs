using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_Score : MonoBehaviour
{
    public Script_New_Ray newRay;
    [SerializeField] TextMeshProUGUI textScore;

    // Update is called once per frame
    void Update()
    {
        Scoring();
    }

    private void Scoring()
    {
        textScore.text = newRay.Score.ToString();
    }
    /*void ScoreFinal() // donner des medaille ou qqc suivant le score je vous laisse imaginer les  recompences
    {
        if (Score == 0)
        {

        }
    }*/
}
