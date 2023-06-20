using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseCharactor : MonoBehaviour
{
    protected Movements movements;

    protected Health health;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        // get move strategy of the character
        movements = GetComponent<Movements>();

        // get health component
        health = GetComponent<Health>();
    }
    // Update is called once per frame
    //void Update()
    //{

    //}

    protected abstract void Die();

}
