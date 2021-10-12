using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;

    public int health = 100;
    public float speed = 5f;
    public int damageDeal = 30;
    public int damageOverTime = 1;
    public int scoreGiven = 20;
    //private float range;
    private bool isFacingLeft = true;

    Vector3 MoveDir;
    private Vector3 Jump;
    public float jumpForce = 0.2f;

    public Animator animator;

    public GameObject deathEffect;
    //public Transform target;
    GameObject player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Transform playerPos = player.transform;
    }

    public void FixedUpdate()
    {
        float horz = MoveDir.x;
        MoveDir = new Vector3(horz, 0.0f, 0.0f);

        if(player != null)
        {
            MoveDir = player.transform.position - transform.position;
            MoveDir = MoveDir.normalized;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }
        animator.SetFloat("Speed", Mathf.Abs(horz));

        if (horz < 0 && !isFacingLeft)
        {
            Flip();
        }
        if (horz > 0 && isFacingLeft)
        {
            Flip();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == player.transform)
        {
            player.GetComponent<Health>().TakeDamage(damageDeal);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform == player.transform)
        {
            player.GetComponent<Health>().TakeDamage(damageOverTime);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag.Equals("Geometry"))
        {
            rb.AddForce(Vector3.up * jumpForce);
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
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.score += scoreGiven;
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
}
