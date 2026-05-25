using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerCollisions : MonoBehaviour //AM
{
    //RM
    //variables
    public static PlayerCollisions instance;
    public bool IsImmune;

    private void Awake()
    {
        instance = this;
    }//end Awake
    //RM

    public bool defeated = false; // stores if player has lost or not
    public bool victory = false; // stores if player has won or not

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // fly collision
        if (collision.transform.tag == "Fly") // checks if colliding with fly collectable
        {
            Destroy(collision.gameObject); // destroys fly when collected
            // update score
            ScoreManager.instance.addScoreFly(); // adds twenty to the score when fly is collected

            //RM
            AudioController.instance.CollectFlyPlay();
            //RM

        }
        // end of fly collision

        // live collisions
        if (collision.transform.tag == "Enemy") // checks if colliding with an enemy
        {
            //RM
            if (IsImmune)
            {
                return;
            }//end if 
            //RM

            HealthManager.health--; // is damaged by 1 
            if (HealthManager.health <= 0) //  if player dies
            {
                gameOver(); // references GO function
            }
            else
            {
                StartCoroutine(GetHurt()); // takes damage and lives
            }

        }// end of enemy collision

        // for spike tiles specifically
        else if (collision.transform.tag == "Spike") // if player collides with a spike
        {
            //RM
            if (IsImmune)
            {
                return;
            }//end if 
             //RM

            HealthManager.health--;// player loses a life
            if (HealthManager.health <= 0)// checks to see if player is still alive
            {
                gameOver(); // references GO function
            }
            else
            {
                StartCoroutine(GetHurt());
            }

        }// end of spike tile collision
         //RM
        else if (collision.transform.tag == "Egg") // if the player is hit by an egg
        {
            Destroy(collision.transform.gameObject); // destroys the egg when kevin collides with it

            //RM
            if (IsImmune)
            {
                return;
            }//end if 
             //RM

            HealthManager.health--; // player loses a life
            if (HealthManager.health <= 0) // checks to see if player is still alive
            {
                gameOver(); // references GO function
            }
            else
            {
                StartCoroutine(GetHurt());
            }

        }// end of spike tile collision
        //RM
        else if (collision.transform.tag == "Shield")
        {

            Destroy(collision.gameObject);
            AudioController.instance.ShieldSFXPLay();
            StartCoroutine(ShieldEffect());

        }// end if
        else if (collision.transform.tag == "Home")
        {
            kevWins();
        }
            
    //RM

    IEnumerator GetHurt() // when player is damaged and doesnt die
        {
            Physics2D.IgnoreLayerCollision(9, 8); // default true // ignores player colliding with enemy

            //RM
            AudioController.instance.KevHurtPlay();
            PlayerMovement.instance.IsHurt = true;
            PlayerMovement.instance.UpdateStateVariable();
            //RM

            yield return new WaitForSeconds(3); // 3 seconds of invulnerability
            Physics2D.IgnoreLayerCollision(9, 8, false); // ignore any collisions with enemy for that time
        }


    } // end of collision detection

    public void gameOver()
    {
        //RM
        AudioController.instance.LoseScreenSFXPlay();
        //RM

        Destroy(GameObject.FindWithTag("Player")); // finds and destorys Kevin GO since not 
        Destroy(GameObject.FindWithTag("Pause")); // finds and pause button on the scene and destroys it so that the player cant acess the menu when they die
        SceneController.Instance.gameOverScreen.SetActive(true); // takes player to GO screen when player dies
        defeated = true;
    } // end of gameOver

   
    public void kevWins()
    {
        //RM
        AudioController.instance.WinScreenSFXPlay();
        //RM

        Destroy(GameObject.FindWithTag("Player")); // finds and destorys Kevin GO since not 
        SceneController.Instance.winScreen.SetActive(true); // takes player to GO screen when player dies
        victory = true;
        WinMenu.Instance.WinScreenLoad();
    } // end of kevWins


    //RM
    IEnumerator ShieldEffect()
    {
        IsImmune = true;
        for (int i = 0; i < 5; i++)//loop x5
        {
            UIManager.Instance.UpdateShieldTimer(i);
            yield return new WaitForSeconds(2);
        }//end for
        IsImmune = false;
    }//end of ShieldEffect
    //RM

} // end of class
//AM
