using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public float speed = 5f;
    public int damageDeal = 40;
    //private float range;
    private bool isFacingLeft = true;
    Vector3 moveDir;

    public Animator animator;

    public GameObject deathEffect;
    public Transform target;

    private Rigidbody rb;

    void Awake()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float Horz = moveDir.x;
        moveDir = new Vector3(Horz, 0.0f, 0.0f);

        if(target != null)
        {
            moveDir = target.position - transform.position;
            moveDir = moveDir.normalized;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
        animator.SetFloat("Speed", Mathf.Abs(Horz));

        if (Horz < 0 && !isFacingLeft)
        {
            Flip();
        }
        if (Horz > 0 && isFacingLeft)
        {
            Flip();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform == target.transform)
        {
            target.GetComponent<Health>().TakeDamage(damageDeal);
            Debug.Log("Player Hit");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
}
