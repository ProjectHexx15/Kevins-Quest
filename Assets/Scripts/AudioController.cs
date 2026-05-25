using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour //RM
{
    //variables
    public static AudioController instance;

    [SerializeField]
    private AudioSource eggCrack;
    [SerializeField]
    private AudioSource enemyDeath;
    [SerializeField]
    private AudioSource kevJump;
    [SerializeField]
    private AudioSource kevHurt1;
    [SerializeField]
    private AudioSource kevHurt2;
    [SerializeField]
    private AudioSource kevHurt3;
    [SerializeField]
    private AudioSource kevSwing1;
    [SerializeField]
    private AudioSource kevSwing2;
    [SerializeField]
    private AudioSource collectFly;
    [SerializeField]
    private AudioSource lowTime;
    [SerializeField]
    private AudioSource shieldSFX;
    [SerializeField]
    private AudioSource loseScreenSFX;
    [SerializeField]
    private AudioSource winScreenSFX;

    private int kevHurtIndex = 0;
    private int kevSwingIndex = 0;
    //end of variables

    private void Awake()
    {
        instance = this;
    }//end awake

    private void Update()
    {
        if ((int)Timer.Instance.remainingTime == 25)
        {
            LowTimePlay();
        }
        else if ((int)Timer.Instance.remainingTime == 0)
        {
            lowTime. Pause();
            LoseScreenSFXPlay();
        }//end if

    }//end of update

    public void EggCrackPlay()
    {
        eggCrack.Play();
    }//end eggCrackPlay

    public void EnemyDeathPlay()
    {
        enemyDeath.Play();
    }//end enemyDeathPlay

    public void KevJumpPlay()
    {
        kevJump.Play();
    }//end of kevJumpPlay

    public void KevHurtPlay()
    {
        if (kevHurtIndex == 0)
        {
            kevHurt1.Play();
            kevHurtIndex++;
        }
        else if (kevHurtIndex == 1)
        {
            kevHurt2.Play();
            kevHurtIndex++;
        }
        else if (kevHurtIndex == 2)
        {
            kevHurt3.Play();
            kevHurtIndex = 0;
        }//end if

    }//end kevHurtPlay

    public void KevSwingPlay()
    {
        if (kevSwingIndex == 0)
        {
            kevSwing1.Play();
            kevSwingIndex++;
        }
        else if (kevSwingIndex == 1)
        {
            kevSwing2.Play();
            kevSwingIndex = 0;
        }//end if

    }//end kevSwingPlay

    public void CollectFlyPlay()
    {
        collectFly.Play();
    }//end of CollectFlyPlay

    public void LowTimePlay()
    {
        lowTime.Play();
    }//end of LowTimePlay

    public void ShieldSFXPLay()
    {
        shieldSFX.Play();
    }//end of ShieldSFXPlay

    public void LoseScreenSFXPlay()
    {
        loseScreenSFX.Play();
    }//end of Lose Screen SFX PLay

    public void WinScreenSFXPlay()
    {
        winScreenSFX.Play();
    }//end of Win Screen SFX PLay

}//end of class
//RM
