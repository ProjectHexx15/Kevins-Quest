using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // to load different scenes and levels

public class SceneController : MonoBehaviour // AM
{
    // references and variables
    public static SceneController Instance; 

    public GameObject gameOverScreen; // references gameOverScreen GO
    public GameObject winScreen; // references winScreen GO
    public GameObject pauseScreen; // references pauseScreen GO

    private void Awake()
    {
        Instance = this; //ensures that this instance of the script is used
    } // end of awake

    public void pause()
    {
        pauseScreen.SetActive(true); // opens the pause menu
        Time.timeScale = 0; // the timer is paused when the game is paused

    } // end of pause

    public void resume()
    {
        pauseScreen.SetActive(false); // closes the pause menu
        Time.timeScale = 1; // time resumes when the game is resumed
    } // end of resume


} // end of class AM
