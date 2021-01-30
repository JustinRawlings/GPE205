using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Set up health and max health
    public TankData data;
    public float currentHealth = 5;
    public float maxHealth = 5;

    private void Start()
    {
        data = GetComponent<TankData>();
    }

    // What happens when we are hit
    public void TakeDamage(float amount, TankData origin)
    {
        currentHealth -= amount;
        Mathf.Clamp(currentHealth, 0.0f, maxHealth);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }


}