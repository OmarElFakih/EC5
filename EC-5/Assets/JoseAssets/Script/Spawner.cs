using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    float random_px;
    Vector3 SpawnerPosition;
    public float SpawnRate = 2f;
    float NextSpawn = 0f;

   

    // Update is called once per frame
    void Update()
    {
        if(Time.time > NextSpawn)
        {
            NextSpawn = Time.time + SpawnRate;
            random_px = Random.Range(-17, 17);
            SpawnerPosition = new Vector3(random_px, transform.position.y,transform.position.z);
            Instantiate(Enemy, SpawnerPosition, Quaternion.identity);
        }
    }
}
