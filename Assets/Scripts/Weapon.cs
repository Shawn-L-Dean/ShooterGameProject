using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public List<GameObject> pooledObj;
    public GameObject objectToPool;
    public int numObjects;

    public Transform firePoint;

    public float speed = 20f;

    void Start()
    {
        pooledObj = new List<GameObject>();
        GameObject bullet;
        for (int i = 0; i < numObjects; i++)
        {
            bullet = Instantiate(objectToPool, firePoint.position, firePoint.rotation);
            bullet.SetActive(false);
            pooledObj.Add(bullet);
        }
    }

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

        //GameObject obj = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        GameObject obj = GetPooledBullet();

        if (obj != null)
        { 
            obj.SetActive(true);

            Vector3 screenMousePosition = Input.mousePosition;
            Vector3 weaponPos = Camera.main.WorldToScreenPoint(firePoint.position);
            Vector3 direction = (screenMousePosition - weaponPos).normalized;

            direction.x *= -1;
            obj.transform.position = firePoint.position;

            Rigidbody rb = obj.GetComponent<Rigidbody>();

            rb.velocity = direction * speed;
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < numObjects; i++)
        {
            if (!pooledObj[i].activeInHierarchy)
            {
                return pooledObj[i];
            }
        }
        return null;
    }
}
