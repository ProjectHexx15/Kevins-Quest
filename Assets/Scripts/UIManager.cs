using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour//RM
{
    //variables
    public static UIManager Instance;
    [SerializeField]
    private Image ShieldTimer;
    [SerializeField]
    private Sprite[] ShieldStage;

    private void Awake()
    {
        Instance = this;
    }//end of awake

    public void UpdateShieldTimer(int currentindex)
    {
        if (currentindex == 0) //checks for the start of the timer to activate the HUD image
        {
            ShieldTimer.gameObject.SetActive(true);
        }
        else if (currentindex == 4) //checks for the end of the timer to deactivate the HUD image
        {
            ShieldTimer.gameObject.SetActive(false); 
            return; //returns from function before sprite can update because it doesn't need to
        }//end if

        ShieldTimer.sprite = ShieldStage[currentindex]; //updates sprite
    }//end of UpdateShieldTimer


}
//RM