using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour//RM
{
    //variables
    [SerializeField]
    private float lifetime;
    //end of variables

    private void Update()
    {
        Destroy(gameObject, lifetime); //unity will count to lifetime before destroying object
    }//end of update

}//end of class
//RM