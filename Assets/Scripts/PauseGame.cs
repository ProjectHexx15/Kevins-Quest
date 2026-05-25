using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour // AM
{

    public GameObject pauseMenu; // references pause menu GO

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) // pause menu is opened when escape is pressed
        {
            pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0; // timer is stoped when pause menu is activated
        }
    } // end of update

} // End of Class AM
