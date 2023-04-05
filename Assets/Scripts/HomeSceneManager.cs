using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeSceneManager : MonoBehaviour
{

    public TMP_Text tmName;
    public TMP_Text tmHighScore;
    public TMP_Text tmGamesPlayed;
    public TMP_Text tmTotalScore;
    //test

    public void GoToGame()
    {

        SceneManager.LoadScene("GameScene");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        //tmTotalScore.text = "Total Score: " + PlayerPrefs.GetInt("OverallScore");
        tmGamesPlayed.text = "# Of Plays: " + PlayerPrefs.GetInt("LaunchCount");
        tmHighScore.text = "Best Run Time: " + PlayerPrefs.GetInt("HighScore");

        if (PlayerPrefs.HasKey("UserName"))
        {
            tmName.text = "Welcome " + PlayerPrefs.GetString("UserName");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
