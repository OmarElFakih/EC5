using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    float random_px;
    public float delaytime;
    Vector3 SpawnerPosition;
    public float SpawnRate = 2f;
    float NextSpawn = 0f;

    private void Start()
    {
        delaytime = Random.Range(10, 60);
        delay(delaytime);
    }

    public void delay(float delaytime)
    {

        InvokeRepeating("spawnSomething", 6, delaytime);
    }
    // Update is called once per frame
   
    public void spawnSomething()
    {
        if (!HealthBar.gameIsOver)
        {
            random_px = Random.Range(-17, 17);
            SpawnerPosition = new Vector3(random_px, transform.position.y, transform.position.z);
            Instantiate(Enemy, SpawnerPosition, Quaternion.identity);
        }
    }
}
