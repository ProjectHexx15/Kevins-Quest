using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour // AM
{
    public Text scoreText;
    public int score = 0;

    public static ScoreManager instance;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString(); // resets the score at the begnining of the level
    } // end of start

    private void Awake()
    {
        instance = this; // very start of game creates instance of score manager
    }


    // Update is called once per frame
    public void addScoreFly()
    {
        score = score + 10; // adds ten points if a fly is collected
        scoreText.text = "Score: " + score.ToString(); // updates the players score
    } // end of add score fly

    public void addScoreEnemy()
    {
        score = score + 20; // adds twenty points an enemy is defeated
        scoreText.text = "Score: " + score.ToString(); // updates the players score
    } // end of add score enemy

    public void addWithTimer()
    {
        if(PlayerCollisions.instance.victory == true) // checks if the player has won or not
        {
            score = score + Timer.Instance.scoreConvert; // adds any remaining time to players score
        }
    } // end of add with timer


} // end of class AM
