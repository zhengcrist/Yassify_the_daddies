using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Health : MonoBehaviour
{
    public int currentHealth = 1;

    public void Damage (int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0) 
        {
            gameObject.SetActive(false);
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Damage(currentHealth);
        }
    }
}
