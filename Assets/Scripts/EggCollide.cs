using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AM
public class EggCollide : MonoBehaviour
{

    public float dropSpeed; // publically stores the eggs drop speed


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground") // if egg colides with ground
        {
            AudioController.instance.EggCrackPlay();
            Destroy(gameObject); // delete the egg GO

        }
    } // end of collistion detectiom


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * dropSpeed);

    } // end of update
} // end of class
// AM
