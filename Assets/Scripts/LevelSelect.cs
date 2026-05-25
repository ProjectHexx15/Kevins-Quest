using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour//RM
{
    //variables
    [SerializeField]
    private Button Lvl2Btn;
    [SerializeField]
    private Button Lvl2BtnGrey;

    [SerializeField]
    private Text Lvl1HighscoreTxt;
    [SerializeField]
    private Text Lvl2HighscoreTxt;

    [SerializeField]
    private Image Homepad;
    [SerializeField]
    private Image HomepadGrey;
    //end of variables

    private void Start()
    {


        if (PlayerPrefs.GetInt("Lvl1Highscore") >= 1) //checks that level has been played at least once
        {
            Lvl1HighscoreTxt.text = "Highscore: " + PlayerPrefs.GetInt("Lvl1Highscore").ToString(); //updates highscore
            Lvl1HighscoreTxt.gameObject.SetActive(true); //shows highscore

            Lvl2Btn.gameObject.SetActive(true); //allows player to click to next level
            Lvl2BtnGrey.gameObject.SetActive(false); //placeholder to show level has not been unlocked, does nothing when clicked
  
        }//end if


        if (PlayerPrefs.GetInt("Lvl2Highscore") >= 1) //checks that level has been played at least once
        {
            Lvl2HighscoreTxt.text = "Highscore: " + PlayerPrefs.GetInt("Lvl2Highscore").ToString(); //updates highscore
            Lvl2HighscoreTxt.gameObject.SetActive(true);//shows highscore

            Homepad.gameObject.SetActive(true); //shows player has completed game
            HomepadGrey.gameObject.SetActive(false); //placeholder which shows player has not completed game yet

        }//end if
       
    }//end start

    public void BackButton()
    {
        SceneManager.LoadScene("TitleScreen"); //loads title screen
    }//end back button

    public void Level1Button()
    {
        SceneManager.LoadScene("Level1"); //loads level 1
        // AM
        Time.timeScale = 1; // when level 1 is loaded the timer wil start again
        // AM
    }//end level 1 button

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2"); //loads level 2
        // AM
        Time.timeScale = 1; // when level 2 is loaded the timer will start again
        // AM
    }//end level 2 button

}//RM
