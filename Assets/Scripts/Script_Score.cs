using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_Score : MonoBehaviour
{
    public int Score;
    [SerializeField]   TextMeshProUGUI textScore;


    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textScore.text = "Score : " + Score; // Change le texte referencer par Score : Valeur du score    
    }
    void ScoreFinal() // donner des medaille ou qqc suivant le score je vous laisse imaginer les  recompences
    {
        if (Score == 0)
        {

        }
    }
}