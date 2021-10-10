using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Logic for shooting projectiles.
        GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 screenMousePosition = Input.mousePosition;
        Vector3 weaponPos = Camera.main.WorldToScreenPoint(firePoint.position);
        Vector3 direction = (screenMousePosition - weaponPos).normalized;

        direction.x *= -1;
        Rigidbody rb = obj.GetComponent<Rigidbody>();

        rb.velocity = direction * speed;
    }    
}
