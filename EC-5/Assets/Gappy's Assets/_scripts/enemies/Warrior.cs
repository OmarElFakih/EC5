using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Soul
{
    [SerializeField]
    private float delay = 0.5f, delayS;

    protected override void Start()
    {
        base.Start();
        delayS = delay;
    }

    private IEnumerator EndProcess()
    {
        yield return new WaitForSeconds(0.45f);
        rb.velocity = Vector2.zero;

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

        //swap sprite scale
        dir.Normalize();
        if (dir.x > 0) model.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else model.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }

    
}
