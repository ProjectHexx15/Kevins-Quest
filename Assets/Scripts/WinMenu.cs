using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour//RM
{
    //variables
    public static WinMenu Instance;
    private UnityEngine.SceneManagement.Scene scene; //used to get current scene name

    [SerializeField]
    private Text finalScoreText;
    [SerializeField]
    private Text highsoreText;
    //end of variables

    private void Awake()
    {
        Instance = this;
        //AM
        Time.timeScale = 1; // when scene is loaded time resumes
        //AM
        scene = SceneManager.GetActiveScene(); //stores current scene name
    }//end of awake

    public void WinScreenLoad() //called when win screen is set to active
    {
        int finalScore = ScoreManager.instance.score + (int)Timer.Instance.remainingTime;

        finalScoreText.text = "Score: " + finalScore.ToString();

        if (scene.name == "Level1") //checks scene name to ensure correct highscore is being used
        {
            if (ScoreManager.instance.score > PlayerPrefs.GetInt("Lvl1Highscore")) //checks if current score is higher than highscore
            {
                PlayerPrefs.SetInt("Lvl1Highscore", finalScore); //updates highscore
            }//end if

            highsoreText.text = "Highscore: " + PlayerPrefs.GetInt("Lvl1Highscore").ToString(); //displays highscore
        }
        else if (scene.name == "Level2") //checks scene name to ensure correct highscore is being used
        {
            if (finalScore > PlayerPrefs.GetInt("Lvl2Highscore")) //checks if current score is higher than highscore
            {
                PlayerPrefs.SetInt("Lvl2Highscore", finalScore); ; //updates highscore
            }//end if

            highsoreText.text = "Highscore: " + PlayerPrefs.GetInt("Lvl2Highscore").ToString(); //displays highscore

        }//end if


    }//end Win Screen Load

    public void ReplayButton()
    {
        Time.timeScale = 1;
        PlayerCollisions.instance.victory = false;
        SceneManager.LoadScene(scene.name);
    }//end of replay button

    public void LevelSelectButton()
    {
        Time.timeScale = 1;
        PlayerCollisions.instance.victory = false;
        SceneManager.LoadScene("LevelSelect");
    }//end level select button

}//end class
//RM