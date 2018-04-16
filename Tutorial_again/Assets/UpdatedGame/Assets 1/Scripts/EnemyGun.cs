using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour 
{
	public GameObject EnemyBulletGO; // our enemy bullet

	// Use this for initialization
	void Start () 
	{
		Invoke ("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// fire enemy bullet
	void FireEnemyBullet()
	{
		// get reference to player's ship
		GameObject playerShip = GameObject.Find("PlayerGO");

		if (playerShip != null) // if player isn't dead
		{
			// instantiate enemy bullet
			GameObject bullet = (GameObject)Instantiate (EnemyBulletGO);

			// bullet's initial position
			bullet.transform.position = transform.position;

			// compute the bullet's direction towards the player's ship
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			// set the bullet's direction
			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
		}
	}
}
