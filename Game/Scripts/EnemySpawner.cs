using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float random;
    Vector2 spawnLocation;
    public float spawnRate = 0.375f;
    float timeToNextSpawn = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
            if (Time.time > timeToNextSpawn)
            {
                timeToNextSpawn = Time.time + spawnRate;
                random = Random.Range(-6.5f, 6.5f);
                spawnLocation = new Vector2(random, transform.position.y);
                Instantiate(enemy, spawnLocation, Quaternion.identity);
                spawnRate -= 0.00000000000005f;
            }

    }
}
