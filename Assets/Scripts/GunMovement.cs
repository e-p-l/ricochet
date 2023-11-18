using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{	
	//General parameterss
	public Camera cam;
	public Transform transform;
	Vector3 touchPos;
	
	void Update(){
		if(transform.tag == "Player1"){
			//Get the input from the touchs
			for (int i = 0; i<Input.touchCount;i++){
				touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
				print(Input.touches[i].position);
			}
			//If the touch is not on the joystick, get the vector and turn the gun
			if(touchPos.x > -3.5 || touchPos.y > -0.5){
				Vector3 lookDir = touchPos - transform.position;
				float angle =  Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
				transform.eulerAngles = new Vector3(0,0,angle);
			}
		}	

		if(transform.tag == "Player2"){
			//Get the input from the touchs
			for (int i = 0; i<Input.touchCount;i++){
				touchPos = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
			}
			//If the touch is not on the joystick, get the vector and turn the gun
			if(touchPos.x < 3.5 || touchPos.y > -0.5){
				Vector3 lookDir = touchPos - transform.position;
				float angle =  Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
				transform.eulerAngles = new Vector3(0,0,angle);
			}
		}	
	}	
}
