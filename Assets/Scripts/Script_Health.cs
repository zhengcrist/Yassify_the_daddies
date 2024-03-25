using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Script_Health : MonoBehaviour
{
    public int currentHealth = 1;
    Script_Score Score;

    public void Damage (int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
        }
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // à debug lol
        Debug.Log("Destroy Collision");
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
    }
}
