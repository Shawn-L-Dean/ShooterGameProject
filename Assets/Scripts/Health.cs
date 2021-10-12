using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{ 
    public int totalHealth;

    public GameObject deathEffect;

    public void Awake()
    {
        GameManager.health = totalHealth;
        totalHealth = 150;
    }

    public void TakeDamage(int damage)
    {
        totalHealth -= damage;
        GameManager.health = totalHealth;

        if (totalHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
