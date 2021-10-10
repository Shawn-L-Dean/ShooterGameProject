using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 50;
    //public Rigidbody thisBody;
    // Start is called before the first frame update
    void Start()
    {
        //thisBody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
