using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour //RM
{
    
    public void StartButton()
    {
        SceneManager.LoadScene("LevelSelect"); //loads level select scene
    }//end of start button

    public void HelpButton()
    {
        SceneManager.LoadScene("HelpScreen"); //loads help screen scene
    }//end of help button

    public void CreditsButton()
    {
        SceneManager.LoadScene("CreditsScreen"); //loads credits screen scene
    }//end of credits button

    public void QuitButton()
    {
        Application.Quit(); //closes game
    }//end of Quit button

}
//RM
