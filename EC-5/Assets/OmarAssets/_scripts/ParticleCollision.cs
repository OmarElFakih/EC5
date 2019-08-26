using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private int _enters = 0;

    private void Start()
    {
        Debug.Log("test");
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Soul"))
        {
            Soul enemy = other.GetComponent<Soul>();
            enemy.TakeDamage(100);
        }
        _enters += 1;
        //Debug.Log("Particle Collision " + _enters);
    }

    private void OnParticleTrigger()
    {
        _enters += 1;
        //Debug.Log("ParticleTrigger " + _enters);
    }
}
