using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{	
	//Keeps track of the number of bounces that the bullet made
	public int numOfBounces = 0;
	public int bounceLimit = 3;
	
	//Rigidbody component of the bullet
	public Rigidbody2D rb;

	//Stores the Velocity and the AngularVelocity of the bullet when it
	//is frozen
	private Vector2 storedVelocity;
	private float storedAngularVelocity;
	private bool isFrozen;

	//Explosion prefab
	public GameObject explosionPrefab;
	public List<GameObject> explosionList = new List<GameObject>();

	//Manages the collision between the Bullet and a Wall/a Player
    private void OnCollisionEnter2D(Collision2D collision){
		//Wall
    	if (collision.gameObject.tag == "Wall"){
			//Instantiating the explosion and adding it to the list of explo
			GameObject explosion = Instantiate(explosionPrefab,collision.otherCollider.transform.position,collision.otherCollider.transform.rotation);
			explosionList.Add(explosion);
			//Increment the numOfBounces
    		numOfBounces += 1;
			//If the bullet bounced enough, freeze it in time
    		if (numOfBounces % bounceLimit == 0){
    			this.Freeze();
    		}
    	}
		//RedPlayer (Player1)
		if (collision.gameObject.tag == "Player1" && !isFrozen){
			//Check if the ball made enough bounces
			if(numOfBounces >= bounceLimit){
				FindObjectOfType<GameManagement>().HurtRed();
			}
			//If not, make the shooter lose a life
			if(numOfBounces < bounceLimit){
				print("Wrong hit");
				print(rb.name);
				if(rb.name == "P1-Bullet(Clone)"){
					FindObjectOfType<GameManagement>().HurtRed();
				}
				if(rb.name == "P2-Bullet(Clone)"){
					FindObjectOfType<GameManagement>().HurtBlue();
				}
			}
		}

		//BluePlayer (Player2)
		if (collision.gameObject.tag == "Player2" && !isFrozen){
			//Check if the ball made enough bounces
			if(numOfBounces >= bounceLimit){
				FindObjectOfType<GameManagement>().HurtBlue();
			}
			//If not, make the shooter lose a life
			if(numOfBounces < bounceLimit){
				print("Wrong hit");
				if(rb.name == "P2-Bullet(Clone)"){
					FindObjectOfType<GameManagement>().HurtBlue();
				}
				if(rb.name == "P1-Bullet(Clone)"){
					FindObjectOfType<GameManagement>().HurtRed();
				}
			}
		}
    }

    //Function to freeze a bullet in time
    public void Freeze(){
		//Store the Velocity/AngularVelocity in variables
    	storedVelocity = rb.velocity;
    	storedAngularVelocity = rb.angularVelocity;
		
		//Set the velocity of the rigidbody to (0,0) and make it Kinematic
    	rb.velocity = Vector2.zero;
		rb.isKinematic = true;
		isFrozen = true;
    }
    


    //Function to unfreeze a bullet in time
    public void Unfreeze(){

		//Undo the Kinematic and give back it's past Velocity/AngularVelocity
    	rb.isKinematic = false;
    	rb.velocity = storedVelocity;
    	rb.angularVelocity = storedAngularVelocity;
		isFrozen = false;

    }

	//Function to destroy all the explosions
	public void ClearExplosions(){
		foreach (GameObject explosions in explosionList){
			Destroy(explosions);
		}
	}

}

