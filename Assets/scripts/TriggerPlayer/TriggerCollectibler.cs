using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollectibler : TriggerBasePlayer
{
    [SerializeField]

    int points;

    [SerializeField]
    const float dyingTime = 0f;

    protected override PlayerTrigger ColliderTypes
    {
        get { return PlayerTrigger.collectible; }
    }

    protected override float GetCollisionReaction()
    {
        Destroy(gameObject, dyingTime);
        return points;
    }
}

