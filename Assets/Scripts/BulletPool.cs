using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> pooledObj;
    public GameObject objectToPool;
    public int numObjects;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObj = new List<GameObject>();
        GameObject bullet;
        for(int i = 0; i < numObjects; i++)
        {
            bullet = Instantiate(objectToPool);
            bullet.SetActive(false);
            pooledObj.Add(bullet);
        }
    }

    public GameObject GetPooledBullet()
    {
        for(int i = 0; i < numObjects; i++)
        {
            if(!pooledObj[i].activeInHierarchy)
            {
                return pooledObj[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
