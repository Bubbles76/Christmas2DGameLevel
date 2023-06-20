using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : baseCharactor
{
    protected override void Die()
    {
        if (health != null)
        {
           // health.Amount = 0;
           
        }

    }
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // check if the player is pressing the left mouse button 
        // and a move strategy has been defined 

        if(Input.GetButton("Fire1") && movements != null)
        {
            movements.Move();
        }
      
    }
    // Receive notification of new GOs and register them
    public void RegisterSceneObjectItem(GameObject sceneObjectItem)
    {
        // Find all GOs that implement PlayerSet on the sceneObjectItem
        PlayerSet[] playerSetters = sceneObjectItem.GetComponents<PlayerSet>();

        if (playerSetters != null)
        {
            // Loop through and set (inject) the player dependency
            foreach (PlayerSet playerSetter in playerSetters)
            {
                playerSetter.SetPlayer(gameObject);
            }
        }

        // register to recevie enemy trigger collisions
        TriggerBasePlayer collider = sceneObjectItem.GetComponent<TriggerBasePlayer>();
        collider.AddPlayerColliderAnnouncement(PlayerTrigger.Enemy, UpdateDamage);
    }

    // recevives enemy collidw notification
    public void UpdateDamage(float damage)
    {
        if (health != null)
        {
            health.Amount = health.Amount - damage;
        }
        Debug.Log("Hurt: " + damage);
    }

    private void OnBecameInvisible()
    {
        Die();
    }

}
