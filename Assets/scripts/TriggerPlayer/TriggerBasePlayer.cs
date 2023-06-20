using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class TriggerBasePlayer : MonoBehaviour,PlayerSet
{
    private PlayerCollideEvent onPlayerCollider;

    private string playerTag;

    protected abstract PlayerTrigger ColliderTypes { get; }

    protected abstract float GetCollisionReaction();

    public void SetPlayer(GameObject gameObjectPlayer)
    {
        playerTag = gameObjectPlayer.tag;
    }

   // method for observer to subscribe to colide events 
   public void AddPlayerColliderAnnouncement(PlayerTrigger colliderTypes, UnityAction<float> action)
    {
        if(colliderTypes==ColliderTypes)
        {
            // initalise event
            if(onPlayerCollider==null)
            {
                onPlayerCollider = new PlayerCollideEvent();
            }
            // add the observer method to send notifation to
            onPlayerCollider.AddListener(action);
        }

    }
    
    private void OnDestroy()
    {
        // clear any event listeners
        if(onPlayerCollider != null)
        {
            onPlayerCollider.RemoveAllListeners();
        }
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collided with player and respond if yes
        if(!string.IsNullOrEmpty(playerTag)&&playerTag.Equals(collision.tag))
        {
            // send event notification with damage / points
            if(onPlayerCollider!=null)
            {
                onPlayerCollider.Invoke(GetCollisionReaction());
            }
        }
    }
}
