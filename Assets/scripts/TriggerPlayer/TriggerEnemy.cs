using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : TriggerBasePlayer
{
    [SerializeField]
    float damage;

    [SerializeField]
    private GameObject damageEffect;

    [SerializeField]
    private float damageEffectDuration = 1f;
  
    protected override float GetCollisionReaction()
    {
        if(damageEffect != null)
        {
            ShowDamage();
        }
      return damage;
    }

    private void ShowDamage()
    {
        // display FX on Collision
        // insantiate prefab and destroy after a while 
        GameObject go = Instantiate(damageEffect, transform.position, transform.rotation);
        go.transform.parent = transform;

        Destroy(go, damageEffectDuration);
    }

    protected override PlayerTrigger ColliderTypes
    {
        get { return PlayerTrigger.Enemy; }
    }
}
