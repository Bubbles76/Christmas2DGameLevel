using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float distanceToFollow;

    // Start is called before the first frame update
    void Start()
    {
        // calculate follow distance offset on x-axis
        // camera's x position - target's (player) x position
        distanceToFollow = transform.position.x - target.position.x;
    }
    private void LateUpdate()
    {
        // get the current position of the target
        float targetX = target.position.x;

        //get the currebt position of the camera
        Vector3 cameraPosition = transform.position;

        // update the position on x
        cameraPosition.x = targetX + distanceToFollow;

        // update the camera's new position
        transform.position = cameraPosition;

    }

}
