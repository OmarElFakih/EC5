using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalPart : MonoBehaviour
{
    public HealthBar hb;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Projectile"))
        {
            hb.TakeDamage(0.05f);
            Destroy(other);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Enemy")) hb.TakeDamage(other.GetComponent<Soul>().data.damage);
        }
    }
}
