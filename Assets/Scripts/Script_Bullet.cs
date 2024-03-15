using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bullet : MonoBehaviour
{
    [SerializeField] float StartTime = 0f;
    [SerializeField] float CurrentTime = 2f;

    [SerializeField] float moveSpeed;
    [SerializeField] private Vector3 scaleChange = new Vector3(0.001f, 0.001f, 0.001f);
    [SerializeField] private bool boolScaleChange = true;

    void Start()
    {
        StartTime = CurrentTime;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveSpeed * Time.deltaTime));
        if (boolScaleChange)
        {
            transform.localScale += scaleChange;
        }
        Timer();
    }

    void Timer()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime <= 0)
        {
            Destroy(gameObject);
        }
    }


    // j'ai mis sur la cible directement, peut changer

    /*void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }*/
}
