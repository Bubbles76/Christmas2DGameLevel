using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : BaseMovements
{
    [SerializeField]
    private float magic;

    public override void Move()
    {
        // get the rigid body component attched to this game object
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();

        // Apply the force to the rigid body in the y- derection
        rigidBody.AddForce(new Vector2(0,magic));

        // get the current velocity of the player from its rigid body component
        Vector2 velicity = rigidBody.velocity;

        //update the velocity on the x-axis to the value of speed
        velicity.x = speed;

        // update the velocity of the rigid body to the new values
        rigidBody.velocity = velicity;
    }
}
