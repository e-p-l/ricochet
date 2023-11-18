using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
	//Animators
	public Animator topAnimator;
	public Animator bottomAnimator;

	//Joysticks
	public Joystick joystick;

	//General parameters
 	public Rigidbody2D rb;
 	public Camera cam;
	public GameObject canvas;
	GameManagement manager;

	//Parameters for movement
 	Vector2 movement;
	public float moveSpeed = 5f;
 	Vector2 mousePos;

	//Parameters for aim
	Vector3 touchPos;
	Vector3 lookDir;
	public bool isAiming;

	
	
	
	void Start(){
		//Initializing the game manager
		manager = canvas.GetComponent<GameManagement>();
	}
    // Update is called once per frame
    void FixedUpdate(){
			/*
			//Movement of Player1
			if(rb.tag == "Player1" && manager.redCanMove){
				//When the player fires, he stops moving
				if(Input.GetButtonDown("P1_Fire")){
					manager.StopRed();
					manager.LoadBlue();
				}
				movement.x = Input.GetAxisRaw("Horizontal");
				movement.y = Input.GetAxisRaw("Vertical");

				mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
			}
			*/
			//Movement of RED
			if(rb.tag == "Player1" && manager.redCanMove){
				//Getting the inputs from the joysticks
				movement.x = joystick.Horizontal;
				movement.y = joystick.Vertical;
				
				//Getting the position of the touches
				for (int i = 0; i<Input.touchCount;i++){
					touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
				}
				
				//If the position is not on the joystick, enable aiming and find the vector
				if(touchPos.x > -3.5 || touchPos.y > -0.5){
					isAiming = true;
					lookDir = touchPos - transform.position;
				}
				//If the fire button is pressed
				//if(Input.GetButtonDown("P2_Fire")){
					//manager.StopBlue();
					//manager.LoadRed();
					//isAiming = false;
				//}

				//ANIMATIONS
				//Bottom
				bottomAnimator.SetFloat("Horizontal",movement.x);
				bottomAnimator.SetFloat("Vertical",movement.y);
				bottomAnimator.SetFloat("Magnitude",movement.sqrMagnitude);
				//Top when moving
				topAnimator.SetFloat("MoveHorizontal",movement.x);
				topAnimator.SetFloat("MoveVertical",movement.y);
				topAnimator.SetFloat("MoveMagnitude",movement.sqrMagnitude);
				//Top when aiming
				topAnimator.SetFloat("AimHorizontal",lookDir.x);
				topAnimator.SetFloat("AimVertical",lookDir.y);
				topAnimator.SetFloat("AimMagnitude",lookDir.sqrMagnitude);
				topAnimator.SetBool("Aim",isAiming);
			}


			//Movement of BLUE
			if(rb.tag == "Player2" && manager.blueCanMove){
				//Getting the inputs from the joysticks
				movement.x = joystick.Horizontal;
				movement.y = joystick.Vertical;
				
				//Getting the position of the touches
				for (int i = 0; i<Input.touchCount;i++){
					touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
				}
				//If the position is not on the joystick, enable aiming and find the vector
				if(touchPos.x < 3.5 || touchPos.y > -0.5){
					isAiming = true;
					lookDir = touchPos - transform.position;
				}
				//If the fire button is pressed
				//if(Input.GetButtonDown("P2_Fire")){
					//manager.StopBlue();
					//manager.LoadRed();
					//isAiming = false;
				//}

				//ANIMATIONS
				//Bottom
				bottomAnimator.SetFloat("Horizontal",movement.x);
				bottomAnimator.SetFloat("Vertical",movement.y);
				bottomAnimator.SetFloat("Magnitude",movement.sqrMagnitude);
				//Top when moving
				topAnimator.SetFloat("MoveHorizontal",movement.x);
				topAnimator.SetFloat("MoveVertical",movement.y);
				topAnimator.SetFloat("MoveMagnitude",movement.sqrMagnitude);
				//Top when aiming
				topAnimator.SetFloat("AimHorizontal",lookDir.x);
				topAnimator.SetFloat("AimVertical",lookDir.y);
				topAnimator.SetFloat("AimMagnitude",lookDir.sqrMagnitude);
				topAnimator.SetBool("Aim",isAiming);
			}		

			//rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
			rb.velocity = new Vector2(movement.x,movement.y) * moveSpeed;
	}


	// Brackeys way to move a rigidbody
	//void FixedUpdate(){
		
	//}	

	public void ButtonClick(){
		if(rb.tag == "Player1" && manager.redCanMove){
			isAiming = false;
		}
		if(rb.tag == "Player2" && manager.blueCanMove){
			isAiming = false;
		}

	}
}
