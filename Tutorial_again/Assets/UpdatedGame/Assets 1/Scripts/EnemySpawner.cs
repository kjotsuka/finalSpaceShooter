using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	public GameObject EnemyGO; 

	float maxSpawnRateInSeconds = 5f;
	public float spawnRate;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Spawn an enemy
	void SpawnEnemy()
	{
		// bottom-left point of screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		// top-right point of screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		// instantiate an enemy
		GameObject anEnemy = (GameObject)Instantiate(EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		// Schedule when to spawn next enemy
		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn()
	{
		float spawnInNSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			spawnInNSeconds = Random.Range (1f, maxSpawnRateInSeconds);
		} else
			spawnInNSeconds = 1f;

		Invoke ("SpawnEnemy", spawnInNSeconds);
	}

	// increase dificulty of game
	void IncreaseSpawnRate()
	{
		if (maxSpawnRateInSeconds > 1f)
			maxSpawnRateInSeconds--;

		if (maxSpawnRateInSeconds == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	// start enemy spawner
	public void ScheduleEnemySpawner()
	{
		// reset max spawn rate
		maxSpawnRateInSeconds = 5f;

		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		// increase spawn rate every 20 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, spawnRate);
	}

	// stop enemy spawner
	public void UnsheduleEnemySpawner()
	{
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
}
