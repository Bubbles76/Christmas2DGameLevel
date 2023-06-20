using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    Movements moveStrategy;

    // Start is called before the first frame update
    void Start()
    {
        moveStrategy = GetComponent<Movements>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveStrategy != null)
        {
            moveStrategy.Move();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

