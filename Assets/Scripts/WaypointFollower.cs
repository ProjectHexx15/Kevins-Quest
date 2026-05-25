using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class WaypointFollower : MonoBehaviour //RM
{

    //variables
    private SpriteRenderer sprite;

    [SerializeField]
    private GameObject[] waypoints; //stores a list of waypoints for an object to follow
    private int currentWaypointIndex;

    [SerializeField]
    private float speed = 2f;
    //end of variables

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }//end start

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) //checks if the distance between the current waypoint and the game object is less than 0.1 (using 0 doesn't work as well)
        {
            currentWaypointIndex++; //moves onto the next waypoint in array
            if (currentWaypointIndex >= waypoints.Length) //ensures index doesnt surpass array length
            {
                currentWaypointIndex = 0;
            }//end if

        }//end if

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); //game object moves towards current waypoint at the preset speed

        if (waypoints[currentWaypointIndex].transform.position.x > transform.position.x) //checks what direction game object is moving in to flip sprite if necessary (on game objects like the spider which do not move horizontally this doesn't have any effect)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }//end if

    }//end update

}//end class
//RM