using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSpawner : MonoBehaviour
{
    public GameObject mob;

    public void Spawn()
    {
        if (!HealthBar.gameIsOver && Random.value > .5)
        {
            Instantiate(mob, transform.position, Quaternion.identity);
        }
    }
}
