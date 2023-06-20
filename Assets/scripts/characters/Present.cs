using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetTracker))]
public class Present : baseCharactor, PlayerSet
{
    [SerializeField]
    private float minFollowDistance = 30f;

    private Transform player;

    private TargetTracker trackTarget;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        trackTarget = GetComponent<TargetTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(movements);
        if (movements != null)
        {
            if (IsTooFarAheadOrBehind())
            {
                Debug.Log("Too far ahead/behind");
                Die();
            }
            else
            {
                movements.Move();
            }
        }
    }

    private bool IsTooFarAheadOrBehind()
    {
        if (trackTarget != null && player != null)
        {
            return trackTarget.IsTargetOutsideRange(player, minFollowDistance);
        }

        return false;
    }

    protected override void Die()
    {
        Destroy(gameObject);
    }

    public void SetPlayer(GameObject gameObjectPlayer)
    {
        player = gameObjectPlayer.transform;
    }
}
