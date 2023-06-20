using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    public bool IsTargetOutsideRange(Transform target, float minFollowDistance)
    {
        // Distance from target on x-axis
        float distance = target.position.x - transform.position.x;

        // -ve target too far behind, +ve too far ahead
        return Mathf.Abs(distance) > minFollowDistance;
    }
}
