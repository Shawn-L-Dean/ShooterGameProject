using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float Radius = 1f;
    public float SpawnInterval = 5f;
    public GameObject EnemyTypeToSpawn = null;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, SpawnInterval);
    }

    void Spawn()
    {
        Vector3 SpawnPos = gameObject.transform.position + Random.onUnitSphere * Radius;
        SpawnPos = new Vector3(SpawnPos.x, SpawnPos.y, 0.0f);
        EnemyTypeToSpawn.transform.position = SpawnPos;
        Instantiate(EnemyTypeToSpawn);
    }
}
