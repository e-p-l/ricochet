using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Start : CanMove ---> Stop ----> CanShoot
//Once 2 balls have stopped : CanMove ----> Stop ----> CanShoot

//Ajouter du delai apres le tir (avant de reactiver move/shoot de lautre joueur)
//Ajouter le Unfreeze de tout les bullets du joueur apres avoir tirer (ou pt avant/pendant A VOIR)





public class GameManagement : MonoBehaviour
{
    public int redHP = 1;
    public int blueHP = 1;

    public GameObject gameOverRed;
    public GameObject gameOverBlue;

    public bool redCanMove = false;
    public bool blueCanMove = false;

    public bool redCanShoot = false;
    public bool blueCanShoot = false;

    public GameObject blueCrosshair;
    public GameObject redCrosshair;

    public GameObject blueJoystick;
    public GameObject redJoystick;

    public GameObject blueFireButton;
    public GameObject redFireButton;

    public PlayerMovement2 bluePlayer;
    public PlayerMovement2 redPlayer;

    public Animator blueTopAnimator;
    public Animator redTopAnimator;
    

    void Start(){
        StopBlue();
        UnloadBlue();
        WakeRed();
        LoadRed();
    }    


    
    // Update is called once per frame
    void Update()
    {
        /*
        //Checks if one of the player gets hit by a ball, if so restarts the scene
        if(redHP <= 0 || blueHP <= 0){
            SceneManager.LoadScene("SampleScene");
        }  
        */
        if(redHP <= 0){
            gameOverRed.SetActive(true);
        }
        if(blueHP <= 0){
            gameOverBlue.SetActive(true);
        }
    }

    //Function to remove 1 life from Red
    public void HurtRed(){
        redHP -= 1;
        FindObjectOfType<AudioManager>().Play("Death");
    }

    //Function to remove 1 life from Blue
    public void HurtBlue(){
        blueHP -= 1;
        FindObjectOfType<AudioManager>().Play("Death");
    }

    public void StopRed(){
        redCanMove = false;
        redPlayer.rb.isKinematic = true;
    }

    public void WakeRed(){
        redCanMove = true;
        redPlayer.rb.isKinematic = false;
    }

    public void StopBlue(){
        blueCanMove = false;
        bluePlayer.rb.isKinematic = true;
    }

    public void WakeBlue(){
        blueCanMove = true;
        bluePlayer.rb.isKinematic = false;
    }

    public void LoadRed(){
        redCanShoot = true;
        redCrosshair.SetActive(true);
        redJoystick.SetActive(true);
        redFireButton.SetActive(true);
        redTopAnimator.SetBool("RedTurn",true);
    }

    public void UnloadRed(){
        redCanShoot = false;
        redCrosshair.SetActive(false);
        redJoystick.SetActive(false);
        redFireButton.SetActive(false);
        redPlayer.isAiming = false;
        redTopAnimator.SetBool("RedTurn",false);
    }

    public void LoadBlue(){
        blueCanShoot = true;
        blueCrosshair.SetActive(true);
        blueJoystick.SetActive(true);
        blueFireButton.SetActive(true);
        blueTopAnimator.SetBool("BlueTurn",true);
    }

    public void UnloadBlue(){
        blueCanShoot = false;
        blueCrosshair.SetActive(false);
        blueJoystick.SetActive(false);
        blueFireButton.SetActive(false);
        bluePlayer.isAiming = false;
        blueTopAnimator.SetBool("BlueTurn",false);
    }
}
