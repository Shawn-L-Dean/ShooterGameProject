using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float SpawnInterval = 5f;
    public GameObject EnemyTypeToSpawn = null;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, SpawnInterval);
        player = GameObject.FindGameObjectWithTag("Player");
        Transform playerPos = player.transform;
    }

    void Spawn()
    {
        Vector3 SpawnPos = gameObject.transform.position;
        SpawnPos = new Vector3(SpawnPos.x, SpawnPos.y, 0.0f);
        EnemyTypeToSpawn.transform.position = SpawnPos;
        Instantiate(EnemyTypeToSpawn, SpawnPos, Quaternion.identity);
    }
}
