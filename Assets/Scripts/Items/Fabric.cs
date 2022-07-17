using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fabric : Item
{
    public override void MoveToFactory(Transform point)
    {
        transform.parent = null;
        StartCoroutine(Move(point));
    }

    public override void MoveToTarget(Transform point)
    {
        StartCoroutine(Move(point));
    }

}
