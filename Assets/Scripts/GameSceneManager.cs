using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameSceneManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameWin;
    public GameObject gameOverDisplay;
    public GameObject gameWinDisplay;

    public TMP_Text tmScore;
    public TMP_Text tmTimeLeft;
    public TMP_Text tmHighScore;
    public TMP_Text launchCount;



    private int MAX_TIME = 60;
    private int currentTime;
    private int currentScore;
    private int highScore;

    public AudioSource gameWinSfx;
    public AudioSource gameLoseSfx;


    public void GoHome()
    {
        if (currentScore < PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }

        
        SceneManager.LoadScene("HomeScene");

    }
    //test
    
    // Start is called before the first frame update
    void Start()
    {
 


        if (PlayerPrefs.HasKey("LaunchCount"))
        {
            // get the current count
            int lc = PlayerPrefs.GetInt("LaunchCount");
            // increment the count
            lc += 1;
            // set to PlayerPrefs
            PlayerPrefs.SetInt("LaunchCount", lc);
        }
        else
        {
            // if not, first time launched, add key
            PlayerPrefs.SetInt("LaunchCount", 1);
        }

        gameOver = false;
        gameWin = false;
        Time.timeScale = 1;

        Debug.Log("Game Begins");
        currentTime = MAX_TIME;

        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            highScore = 0;
        }

        StartCoroutine("LoseTime");


    }

    private void updateLabels()
    {
        tmTimeLeft.text = "Time Left: " + currentTime;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentTime--;

            if(currentTime <= 0)
            {
                break;
            }

        }
        GameOver();
    }

    private void GameOver()
    {
        if(highScore < currentScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
    // Update is called once per frame
    void Update()
    {
        updateLabels();

        if(currentTime <= 0 || gameOver)
        {
            gameOver = true;
            gameLoseSfx.Play();
            Time.timeScale = 0;
            gameOverDisplay.SetActive(true);
        }
 
        if (gameWin)
        {
            gameWinSfx.Play();
            currentScore = MAX_TIME - currentTime;
            tmScore.text = "Score: " + currentScore;
            Time.timeScale = 0;
            gameWinDisplay.SetActive(true);
        }
    }
}
