using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demigod : Soul
{

    [Header("delay")]
    public float delay = 3f;
    public float shotdelay = 2f;
    public float firerate = 1f;
    private float delayS;

    [Header("shoot data")]
    public GameObject projectile;

    private bool canShoot = true;

    protected override void Start()
    {
        base.Start();
        delayS = delay;
        InvokeRepeating("shoot", shotdelay, firerate);
    }

    private IEnumerator EndProcess()
    {
        yield return new WaitForSeconds(0.7f);
        rb.velocity = Vector2.zero;

    }

    protected override void OnDeath()
    {
        canShoot = false;
        base.OnDeath();
    }

    protected override void MoveTowardsTarget(GameObject target)
    {
        Vector2 dir = new Vector2(target.transform.position.x - rb.position.x, target.transform.position.y - rb.position.y);
        if (delay <= 0)
        {

            dir.Normalize();
            rb.velocity.Normalize();
            rb.AddForce(dir * data.speed, ForceMode2D.Impulse);
            StartCoroutine(EndProcess());
            delay = delayS;

        }
        else
        {
            delay -= Time.deltaTime;
            //rb.velocity = Vector2.zero;
        }

    }

    void shoot()
    {
        if (canShoot)
        {
            GameObject obj = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector2 dir = new Vector2(target.transform.position.x - rb.position.x, target.transform.position.y - rb.position.y);
        }
    }
  
}
