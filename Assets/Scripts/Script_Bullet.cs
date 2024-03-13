using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Bullet : MonoBehaviour
{
    [SerializeField] float StartTime = 0f;
    [SerializeField] float CurrentTime = 3f;

    [SerializeField] float moveSpeed = 7f;
    [SerializeField] private Vector3 scaleChange;

    void Start()
    {
        scaleChange = new Vector3(0.001f, 0.001f, 0.001f);
        StartTime = CurrentTime;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (moveSpeed * Time.deltaTime));
        transform.localScale += scaleChange;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
