using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commoner : Soul
{
    protected override void MoveTowardsTarget(GameObject target)
    {

        rb.position = Vector2.MoveTowards(rb.position, target.transform.position, Time.deltaTime * data.speed);

        //swap sprite scale 
        Vector2 dir = new Vector2(target.transform.position.x - rb.position.x, target.transform.position.y - rb.position.y);
        dir.Normalize();
        if (dir.x > 0) model.transform.localScale= new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        else model.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }
}
