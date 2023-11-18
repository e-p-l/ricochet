using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public Animator animator;
	public Joystick joystick;

 	public float moveSpeed = 5f;
 	public Rigidbody2D rb;
 	public Camera cam;

 	Vector2 movement;
 	Vector2 mousePos;

	public GameObject canvas;
	GameManagement manager;
	
	
	void Start(){
		manager = canvas.GetComponent<GameManagement>();
	}
    // Update is called once per frame
    void Update(){
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

			//Movement of Player2
			if(rb.tag == "Player2" && manager.blueCanMove){
				if(Input.GetButtonDown("P2_Fire")){
					manager.StopBlue();
					manager.LoadRed();
				}
				//movement.x = Input.GetAxisRaw("P2_Horizontal");
				//movement.y = Input.GetAxisRaw("P2_Vertical");

				movement.x = joystick.Horizontal;
				movement.y = joystick.Vertical;

				animator.SetFloat("Horizontal",movement.x);
				animator.SetFloat("Vertical",movement.y);
				animator.SetFloat("Magnitude",movement.sqrMagnitude);

				//mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

			}		
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		
		//Vector2 lookDir =  mousePos - rb.position;
		//float angle =  Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f; 
		//rb.rotation = angle;
	}
	
}
