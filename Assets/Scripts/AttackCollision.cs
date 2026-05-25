using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackCollision : MonoBehaviour //RM
{
    //variables
    [SerializeField]
    private float AttackCooldown = 2f;
    private float NextAttack;
    [SerializeField]
    private GameObject enemyDeathEffect;
    //end of variables

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Time.time > NextAttack)
        {
            AudioController.instance.EnemyDeathPlay();
            Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation); //creates a death effect for the enemy
            Destroy(other.transform.parent.gameObject); //destroys not only the enemy game object but also its waypoints
            transform.gameObject.SetActive(false); //deactivates itself before coroutine so multiple enemies cannot be hit in one swing
            NextAttack = Time.time + AttackCooldown; //increases when player can attack again by the cooldown
            //AM
            ScoreManager.instance.addScoreEnemy(); // adds twenty to the total score when an enemy is killed
            //AM

        }//end if

    }//end on trigger enter 2d

}//end class
//RM
