using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class SettingsSceneManager : MonoBehaviour
{
    public TMP_InputField inputName;

    public void ResetStats()
    {
        //reset name
        PlayerPrefs.SetInt("UserName", 0);
        //best run time
        PlayerPrefs.SetInt("HighScore", 0);
        //number of game plays
        PlayerPrefs.SetInt("LaunchCount", 0);
    }
    public void GoHome()
    {
        PlayerPrefs.SetString("UserName", inputName.text);
        SceneManager.LoadScene("HomeScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("UserName"))
        {
            inputName.text = PlayerPrefs.GetString("UserName");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
