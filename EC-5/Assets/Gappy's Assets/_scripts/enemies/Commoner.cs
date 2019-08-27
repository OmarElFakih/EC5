using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commoner : Soul
{
    protected override void MoveTowardsTarget(GameObject target)=> rb.position = Vector2.MoveTowards(rb.position, target.transform.position, Time.deltaTime * data.speed);
}
