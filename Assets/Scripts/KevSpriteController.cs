using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class KevSpriteController : MonoBehaviour //RM
{
    //variables
    private SpriteRenderer sprite;
    private Animator anim;
    private float ParentDirection;
    //end variables

    private void Start()
    {
        //populates variables that need data from a component
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }//end start


    void Update()
    {
        ParentDirection = gameObject.transform.parent.gameObject.GetComponent<PlayerMovement>().dirX; //gets reference to parent object's direction

        if (ParentDirection < 0f) //checks if player is moving left
        {
            sprite.flipX = true; //flips sprite to face left
            
        }
        else if (ParentDirection > 0f) //checks if player is moving right
        {
            sprite.flipX = false; //unflips sprite to be facing right
            
        }//end if

    }//end update


    public void UpdateAnimationState(int state)
    {
        anim.SetInteger("state", state); //updates sprite to match variable from player movement
    }//end of update animation state

    public void ResetAttack() //called after attack animation plays
    {
        PlayerMovement.instance.IsAttacking = false;
    }//end of reset attack

    public void ResetHurt() //called after hurt animation plays
    {
        PlayerMovement.instance.IsHurt = false;
    }//end of reset hurt

}//end class
//RM