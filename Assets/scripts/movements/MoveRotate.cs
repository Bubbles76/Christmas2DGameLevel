using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotate : BaseMovements
{
    public override void Move()
    {
        // rotate the object around its position, in a forward dircetion make the speed frame rate indep by mult by delta time
        transform.RotateAround(transform.position, Vector3.forward, speed * Time.fixedDeltaTime);
    }
}
