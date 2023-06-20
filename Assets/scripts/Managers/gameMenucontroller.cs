using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameMenucontroller : MonoBehaviour
{

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text timerText;

    [SerializeField]
    GameObject healthPointBar;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    Button Level1Button;

    [SerializeField]
    Text Level1ButtonText;


    [SerializeField]
    Button Level2Button;

    [SerializeField]
    Text Level2ButtonText;


    [SerializeField]
    Button Level3Button;

    [SerializeField]
    Text Level3ButtonText;


    [SerializeField]
    Text gameOverText;

    private float hpBarFullWidth;
    private RectTransform hpRectTransform;
    private bool isMenuShowing;

    // Start is called before the first frame update
    void Start()
    {
        CalculateHPBarWidth();
        UpdateHealthDisplay();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Level2Button.interactable = false;
        Level3Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                Level2Button.interactable = true;

                break;
            case 2:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {
        //! is not 
        if (!gameManager.IsGameOver)
        {
            UpdateUIText();
        }
    }
   
    int levelPassed;


    public void levelToLoad(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void resetPlayerPrefs()
    {
        Level2Button.interactable = false;
        Level3Button.interactable = false;
        PlayerPrefs.DeleteAll();

    }


    void UpdateUIText()
    {
        if (scoreText != null)
        {
            scoreText.text = string.Format("{0:00000}", gameManager.Score);
        }

        if (timerText != null)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", gameManager.TimeElapsed.Hours, gameManager.TimeElapsed.Minutes, gameManager.TimeElapsed.Seconds);
        }
    }

    void CalculateHPBarWidth()
    {

        if (healthPointBar != null)
        {
            // get the rectangle transform component attacched to the HP Bar
            hpRectTransform = healthPointBar.GetComponent<RectTransform>();


            //get the width 
            //  full bar means 100% health
            hpBarFullWidth = hpRectTransform.rect.width;
        }
    }

    public void UpdateHealthDisplay()
    {
        // do not continue the code its gameover
        if (gameManager.IsGameOver) return;

        if (healthPointBar != null)
        {
            // calculate new width based on health percentage value
            float newWidth = gameManager.PlayerHealthPercent / 100f * hpBarFullWidth;

            // set health point bar to new with to give illusion of decreasing health
            hpRectTransform.sizeDelta = new Vector2(newWidth, hpRectTransform.rect.height);
        }
    }

}
