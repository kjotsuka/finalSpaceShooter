﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour 
{
	public GameObject EnemyBulletGO; // our enemy bullet
	public float fireRate;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () 
	{
		//Invoke ("FireBossBullet", 1f);
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			FireBossBullet ();
		}
	}

	// fire enemy bullet
	void FireBossBullet()
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
			//Vector2 direction = playerShip.transform.position - bullet.transform.position;
			Vector2 direction = new Vector2(0,-1); // This way the bullets only go straight down. 

			// set the bullet's direction
			bullet.GetComponent<EnemyBullet> ().SetDirection (direction);
		}
	}
}
