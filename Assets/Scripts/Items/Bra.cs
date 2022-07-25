using UnityEngine;

public class Bra : Item
{
    public override void Move(Transform target)
    {
        if (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

        transform.rotation = Quaternion.identity;
    }
}
