using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// holds all game information 

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Register to know when it is game over")]
    private GameOverEvent onGameOver;
    public float Score { get; private set; } = 0;

    public bool IsGameOver { get; private set; }

    public bool IsPaused { get; private set; }

    public float PlayerHealthPercent { get; private set; } = 100;

    public TimeSpan TimeElapsed
    {
        get
        {
            return new TimeSpan(0, 0, (int)timer);
        }
    }
    private float timer = 0;

    public void CollectPoints(float points)
    {
       Score = Score + points;

        Debug.Log("Score: " + Score);
    }
    public void OnPLayerHealthChange(float newHealth)
    {
        PlayerHealthPercent = newHealth;
    }

    public void RegisterSceneObjectItem(GameObject sceneObjectItem)
    {
        // register to recevie cellectible  trigger collisions
        TriggerBasePlayer collider = sceneObjectItem.GetComponent<TriggerBasePlayer>();
        collider.AddPlayerColliderAnnouncement(PlayerTrigger.collectible, CollectPoints);
    }
    private void FixedUpdate()
    {
        if (!IsGameOver || !IsPaused)
        {
            timer += Time.fixedDeltaTime;
        }
    }

    public void OnPlayerDies()
    {
        IsGameOver = true;
        PauseGame(true);

        // broadcast game over event
        if (onGameOver != null)
        {
            onGameOver.Invoke();
        }
    }

    public void PauseGame(bool setPaused)
    {
        if (setPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        IsPaused = setPaused;
    }

}

