using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAndRight : BaseMovements
{
    [SerializeField]
    bool MoveLeft = true;
    [SerializeField]
    bool MoveRight = false;

    Vector3 currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentDirection();
    }

    void SetCurrentDirection()
    {
        currentDirection = Vector3.left;
        if(MoveLeft == false && MoveRight == true)
        {
            currentDirection = Vector3.right;
        }
    }
    public override void Move()
    {
        // move forward continuosly on the y-axis in the current direction based on the speed
        transform.Translate(currentDirection * speed * Time.deltaTime); //Time.deltaTime makes frame rate independant
    }
}
