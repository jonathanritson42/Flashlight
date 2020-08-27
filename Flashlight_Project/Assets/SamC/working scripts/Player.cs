using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public void Start()
    {
        currentHealth = maxHealth;
        //sets health to 100
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //removes a given amount of damage
        healthBar.SetHealth(currentHealth);
        //updates the healthbar UI
    }
}
