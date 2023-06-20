using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovements : MonoBehaviour,Movements
{
    [SerializeField]
    protected float speed;

    public abstract void Move();

}
