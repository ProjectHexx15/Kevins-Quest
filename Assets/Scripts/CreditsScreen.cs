using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreen : MonoBehaviour//RM
{
    public void BackButton()
    {
        SceneManager.LoadScene("TitleScreen"); //load title screen
    }//end of back button

    public void EraseData()
    {
        //highscores are reset
        PlayerPrefs.SetInt("Lvl1Highscore", 0);
        PlayerPrefs.SetInt("Lvl2Highscore", 0);

        //level select screen is loaded to give visual feedback on the scores being reset
        SceneManager.LoadScene("LevelSelect");

    }//end of erase data

}//RM
