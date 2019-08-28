using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalPart : MonoBehaviour
{
    public HealthBar hb;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (gameObject.CompareTag("Boat"))
        {
            if (other.CompareTag("Projectile"))
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                hb.TakeDamage(0.20f);
                Destroy(other);
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (other.CompareTag("Enemy")) hb.TakeDamage(other.GetComponent<Soul>().damage);
        }
    }
}
