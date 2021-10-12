/*
 * Created By: Shawn Dean
 * Date Created: October 5, 2021
 * 
 * Last Edited By: Shawn Dean
 * Last Updated: October 7, 2021
 * 
 * Description: Health of player
 */

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
