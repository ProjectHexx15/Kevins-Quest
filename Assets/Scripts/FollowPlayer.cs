using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //variables
    [SerializeField]
    public Transform player; //reference to player GO
    //end of variables

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //camera and background move with player
    }//end update

}//end class
