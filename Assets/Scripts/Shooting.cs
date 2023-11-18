using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{   

    //General parameters
    public Transform firePoint;
    public GameObject canvas;
	GameManagement manager;
    
    //Bullets parameters
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    //Keeping track of bullets parameters
    public int bulletShot = 0;
    public List<GameObject> bulletList = new List<GameObject>();

	void Start(){
		manager = canvas.GetComponent<GameManagement>();
	}

    /*
    // Update is called once per frame
    void Update()
    {
        //Shooting for Player1
        if(firePoint.tag == "Player1"){
            //Checking for input and if it's the player's turn
            if(Input.GetButtonDown("P1_Fire") && manager.redCanShoot){
                bulletShot += 1;
                //Unfreezing every already shot bullet
                foreach (GameObject bulletGO in bulletList){
                    Bullet bulletComponent = bulletGO.GetComponent<Bullet>();  
                    bulletComponent.Unfreeze();
                    bulletComponent.ClearExplosions();
                }
                Shoot();
                manager.UnloadRed();
                manager.LoadBlue();
                manager.WakeBlue();
    	    }
        }

        //Shooting for Player2
        if(firePoint.tag == "Player2" && manager.blueCanShoot){
            //Checking for input and if it's the player's turn
            if(Input.GetButtonDown("P2_Fire")){
                bulletShot += 1;
                //Unfreezing every already shot bullet
                foreach (GameObject bulletGO in bulletList){
                    Bullet bulletComponent = bulletGO.GetComponent<Bullet>();  
                    bulletComponent.Unfreeze();
                }
                Shoot();
                manager.UnloadBlue();
                manager.LoadRed();
                manager.WakeRed();   
    	    }
        }
    }
    */

    public void BlueShoot(){
        //Increment the number of bulletshot (Just an info to debug)
        bulletShot += 1;
        //Unfreezing every already shot bullet
        foreach (GameObject bulletGO in bulletList){
            Bullet bulletComponent = bulletGO.GetComponent<Bullet>();  
            bulletComponent.Unfreeze();
            bulletComponent.ClearExplosions();
        }

        //Instantiate a new bullet, give it force and add it to the list of bullets
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb  = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletList.Add(bullet);

        FindObjectOfType<AudioManager>().Play("Gunshot");

        //Go to the red turn
        manager.UnloadBlue();
        manager.StopBlue();

        manager.LoadRed();
        manager.WakeRed();   

    }

    public void RedShoot(){
        //Increment the number of bulletshot (Just an info to debug)
        bulletShot += 1;
        //Unfreezing every already shot bullet
        foreach (GameObject bulletGO in bulletList){
            Bullet bulletComponent = bulletGO.GetComponent<Bullet>();  
            bulletComponent.Unfreeze();
            bulletComponent.ClearExplosions();
        }

        //Instantiate a new bullet, give it force and add it to the list of bullets
        GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Rigidbody2D rb  = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletList.Add(bullet);

        FindObjectOfType<AudioManager>().Play("Gunshot");

        //Go to the blue turn
        manager.UnloadRed();
        manager.StopRed();

        manager.LoadBlue();
        manager.WakeBlue(); 

    }

    /*
    public void Shoot(){
    	GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    	Rigidbody2D rb  = bullet.GetComponent<Rigidbody2D>();
    	rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bulletList.Add(bullet);
    }
    */
}
