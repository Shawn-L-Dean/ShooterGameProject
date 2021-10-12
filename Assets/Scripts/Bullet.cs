using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float timeActive = 5f;

    void Start()
    {
        InvokeRepeating("Disable", timeActive, timeActive);
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        gameObject.SetActive(false);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
