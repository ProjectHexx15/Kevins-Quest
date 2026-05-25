using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour //AM
{
    public static Timer Instance;

    [SerializeField] TextMeshProUGUI timerText; // stores the timer text object
    [SerializeField] public float remainingTime; // elapsed time of the game
    public int scoreConvert;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0) // if theres is still time remaining
        {
            remainingTime -= Time.deltaTime; // stores the time elapsed of the game
            timeGOcheck();
            
        }
        else if (remainingTime <= 0) // checks if the timer has ran out
        {
           
            remainingTime = 0; // timer will not go into minus
            Destroy(GameObject.FindWithTag("Player")); // finds and destorys Kevin GO since not 
            SceneController.Instance.gameOverScreen.SetActive(true); // takes player to GO screen when player dies

        }

    
        float minutes = Mathf.FloorToInt(remainingTime / 60); // calculates minutes
        float seconds = Mathf.FloorToInt(remainingTime % 60); // calculates seconds
        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds); // updates the timer using the specific format


    } // end of update

    public void timeGOcheck()
    {
        if (PlayerCollisions.instance.defeated == true) // checks if player has been defeated
        {
            Time.timeScale = 0; // timer is stoped if player is dead

        }
        else if(PlayerCollisions.instance.victory == true) // checks if the player has beat the level
        {
            scoreConvert = (int)remainingTime; // converts the games remaining time into an integer for the players score
            
            
            Time.timeScale = 0; // timer stops when the player wins
        }
        
    }


} // End of Class AM
