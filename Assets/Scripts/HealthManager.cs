using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour //AM
{
    // variables
    public static int health = 3; // stores the players health

    public Image[] hearts; // array of hearts
    public Sprite fullHeart; // full heart sprite
    public Sprite emptyHeart; // empty heart sprite
    
    private void Awake()
    {
        health = 3; // health is reset when level is restarted
    } // end of awake



    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts ) // for each heart in heart array
        {
            img.sprite = emptyHeart; // changes to emptyheart when damaged
        } // end of for each
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart; // non damaged hearts stay the same graphic
        } // end of for
            
    } // end of update
} // end of class
//AM
