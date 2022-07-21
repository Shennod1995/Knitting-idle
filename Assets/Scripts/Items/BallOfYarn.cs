using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOfYarn : Item
{
    public override void Move(Transform target)
    {
        if (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

        transform.rotation = target.rotation;
    }
}
