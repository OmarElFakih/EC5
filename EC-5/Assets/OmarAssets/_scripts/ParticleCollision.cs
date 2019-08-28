using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private int _enters = 0;
    private GameObject target;
    [SerializeField]
    float magnitude = 5000f;

    private void Start()
    {
        //Debug.Log("test");
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private IEnumerator End(Rigidbody2D body)
    {
        yield return new WaitForSeconds(0.6f);
        body.velocity = Vector2.zero;
        body.isKinematic = false;
    }

    private void Knockback(GameObject other)
    {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();
        
        Vector2 dir = new Vector2(targetRb.position.x - otherRb.position.x, targetRb.position.y - otherRb.position.y);
        dir.Normalize();
        otherRb.AddForce(-dir * magnitude, ForceMode2D.Impulse);
        StartCoroutine(End(otherRb));

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Enemy"))
        {
            Soul enemy = other.GetComponent<Soul>();
            enemy.TakeDamage(100);
            Knockback(other);
           // Debug.Log("particle collision");
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
