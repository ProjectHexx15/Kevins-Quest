using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour //RM
{
    //variables
    public static PlayerMovement instance;

    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField]
    private LayerMask jumpableGround;

    public float dirX = 0f; //current direction Player is going
    [SerializeField]
    private float speed = 7f; //controls how fast the player can move
    [SerializeField]
    private float jumpForce = 7f; //controls how high Player can jump
    [SerializeField]
    public Transform AttackRange; //an empty game object with a box collider trigger and the attack script attached to it
    [SerializeField]
    private GameObject RegularKevSprite;
    [SerializeField]
    private GameObject ArmourKevSprite;
    private GameObject currentSprite;
    private enum MovementState { idle, moving, jumping, falling, attacking, hurt } //this is the variable that stores what movement state the current sprite animation should corelate to
    public bool IsAttacking;
    public bool IsHurt;
    //end of variables


    private void Awake()
    {
        instance = this;
    }//end awake

    private void Start()
    {
        //populates variables that need data from a component
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        currentSprite = RegularKevSprite;
    }//end start

    private void Update()
    {

        if (PlayerCollisions.instance.IsImmune) //checks if player has shield effect to update sprite
        {
            RegularKevSprite.SetActive(false);
            ArmourKevSprite.SetActive(true);
            currentSprite = ArmourKevSprite;
        }
        else
        {
            ArmourKevSprite.SetActive(false);
            RegularKevSprite.SetActive(true);
            currentSprite = RegularKevSprite;
        }//end if

        dirX = Input.GetAxisRaw("Horizontal"); //gets direction from user input
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y); //applies velocity to player


        if (Input.GetButtonDown("Jump") && IsGrounded() || Input.GetKeyDown("up") && IsGrounded() || Input.GetKeyDown(KeyCode.W) && IsGrounded()) //accomodates for all movement inputs and ensures Player is on the ground before jumping
        {
            AudioController.instance.KevJumpPlay();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }//end if


        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) //gets attack input
        {
            StartCoroutine(Attack()); //calls attack coroutine to activate hit box for a short time
            IsAttacking = true;
        }//end if

        UpdateStateVariable();

    }//end update


    public void UpdateStateVariable()
    {
        MovementState state;

        if (dirX > 0f) //checks if player is moving right
        {
            state = MovementState.moving; //updates variable to change sprite to moving
            AttackRange.localPosition = new Vector2(1.15f, 0f); //moves attack range box to be in the direction player is facing
        }
        else if (dirX < 0f) //checks if player is moving left
        {
            state = MovementState.moving; //updates variable to change sprite to moving
            AttackRange.localPosition = new Vector2(-1.15f, 0f); //moves attack range box to be in the direction player is facing
        }
        else //if player is not moving 
        {
            state = MovementState.idle; //updates variable to change sprite to idle
        }//end if


        if (rb.velocity.y > .1f) //if upwards velocity is applied 
        {
            state = MovementState.jumping; //updates variable to change sprite to jumping
        }
        else if (rb.velocity.y < -.1f) //if downwards velocity is applied
        {
            state = MovementState.falling; //updates variable to change sprite to falling
        }//end if

        if (IsAttacking)
        {
            state = MovementState.attacking;//updates variable to change sprite to attacking
        }

        if (IsHurt)
        {
            state = MovementState.hurt;//updates variable to change sprite to hurt
        }

        currentSprite.GetComponent<KevSpriteController>().UpdateAnimationState((int)state); //calls the update animation function on the current sprite

    }//end of update state variable

    private bool IsGrounded()//called when player attempts to jump
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        //creates a second box overlapping the collider, offset slightly at the bottom, which can be used to check if the player is on the ground
    }//end of IsGrounded

    IEnumerator Attack() //called when player presses either mouse button to attack
    {
        AudioController.instance.KevSwingPlay();
        AttackRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(1); //this should match how long the attack animation is
        AttackRange.gameObject.SetActive(false);
        
    }//end of attack coroutine


}//end class
//RM