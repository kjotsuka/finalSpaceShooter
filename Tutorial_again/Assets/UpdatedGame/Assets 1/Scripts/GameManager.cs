using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner; // reference to our enemy spawner
	public GameObject GameOverGO; // reference to game over image
	public GameObject scoreUITextGO; // reference to the score text UI game object
	public GameObject TimeCounterGO; // reference to ther time counter game object
	public GameObject GameTitleGo; // reference to the GameTitleGo
	public GameObject ShootButton; // reference to the shoot button game object
	public GameObject LeftButton; // reference to the left arrow button game object
	public GameObject RightButton; // reference to the right arrow button game object
	public GameObject meteorSpawner; // reference to our meteor spawner
	public GameObject quitButton; // reference to the quit button game object
	public GameObject storeButton; // reference to the store button game object
	public GameObject nextLevelButton; // reference to the next level button
	public GameObject BossSpawner; // reference to the BossSpawner
	public GameObject retryButton; // reference to the retry button

	public int level;

	// added for buttons
	//public GameObject TouchController; // reference to the TouchController game object

	public enum GameManagerState
	{
		Opening,
		Gameplay,
		GameOver,
		EndLevel,
	}

	GameManagerState GMState;

	// Use this for initialization
	void Start () 
	{
		GMState = GameManagerState.Opening;
	}
	
	// update game manager state
	void UpdateGameManagerState()
	{
		switch (GMState) 
		{
		case GameManagerState.Opening:

			// display the game title
			GameTitleGo.SetActive (true);

			// Hide game over
			GameOverGO.SetActive(false);

			// Display the game title
			GameTitleGo.SetActive(true);

			// Set play button visible (active)
			playButton.SetActive(true);

			// Hide left && right button
			//TouchController.SetActive(false);

			break;
		case GameManagerState.Gameplay:

			// Reset the score
			scoreUITextGO.GetComponent<GameScore> ().Score = 0;

			// hide next level button
			nextLevelButton.SetActive(false);

			// hide quit button
			quitButton.SetActive(false);

			// hide store button
			storeButton.SetActive(false);

			// hide retry button 
			retryButton.SetActive(false);

			// hide play button on game play state
			playButton.SetActive (false);

			// hide the game title
			GameTitleGo.SetActive (false);

			// hide game over 
			GameOverGO.SetActive(false);

			// display the shoot button
			ShootButton.SetActive (true);

			// display the left arrow button
			LeftButton.SetActive (true);

			// display the right arrow button
			RightButton.SetActive (true);

			// set the player visible (active) and init the player lives
			playerShip.GetComponent<PlayerControl> ().Init ();

			// start enemy spawner
			enemySpawner.GetComponent<EnemySpawner> ().ScheduleEnemySpawner ();

			// start the time counter
			TimeCounterGO.GetComponent<TimeCounter> ().StartTimeCounter ();

			// start meteor spawner
			meteorSpawner.GetComponent<MeteorSpawner> ().ScheduleMeteorSpawner ();

			break;
		case GameManagerState.GameOver:

			// if boss is active, and you lose, then set bossNumber to zero
			TimeCounterGO.GetComponent<TimeCounter>().bossNumber = 0;

			// stop the time counter
			TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

			// Stop enemy spawner
			enemySpawner.GetComponent<EnemySpawner>().UnsheduleEnemySpawner();

			// stop meteor spawner
			meteorSpawner.GetComponent<MeteorSpawner>().UnsheduleEnemySpawner();

			// destroy boss if it is there
			BossSpawner.GetComponent<BossSpawner>().DestroyBoss();

			// hide the shoot button
			ShootButton.SetActive(false);

			// hide the left arrow button
			LeftButton.SetActive(false);

			/// hide the right arrow button
			RightButton.SetActive(false);

			// Display retry button
			retryButton.SetActive(true);

			// Display game over
			GameOverGO.SetActive(true);

			// Change game manager state to Opening state after 5 seconds
			//Invoke("ChangeToOpeningState", 5f);

			break;
		case GameManagerState.EndLevel:

			// stop the time counter
			TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();

			// Stop enemy spawner
			enemySpawner.GetComponent<EnemySpawner>().UnsheduleEnemySpawner(); // This is probably already done since you're at the boss

			// stop meteor spawner
			meteorSpawner.GetComponent<MeteorSpawner>().UnsheduleEnemySpawner(); // same as enemySpawner, possibly already done. 

			// Display quit button
			quitButton.SetActive(true);

			// Display store button
			storeButton.SetActive(true);

			// Display next level button
			nextLevelButton.SetActive(true);

			// Display retry button
			retryButton.SetActive(true);

			// hide shoot button
			ShootButton.SetActive(false);

			// hide left arrow button
			LeftButton.SetActive(false);

			// hide right arrow button
			RightButton.SetActive(false);

			// hide player ship
			playerShip.SetActive(false);

			break;
		}
	}

	// set game manager state
	public void SetGameManagerState(GameManagerState state)
	{
		GMState = state;
		UpdateGameManagerState ();
	}

	// Out play button will call this function
	// when the user clicks the button
	public void StartGamePlay()
	{
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	// change game manager state to opening state
	public void ChangeToOpeningState()
	{
		SetGameManagerState (GameManagerState.Opening);
	}

	// Load the next level
	public void NextLevel()
	{
		if (level == 1) 
		{
			level++;
			Application.LoadLevel ("Level2");
		} 
		else if (level == 2) 
		{
			level++;
			Application.LoadLevel ("Level3");
		} 
		else if (level == 3) 
		{
			level++;
			Application.LoadLevel ("Level4");
		}
		else if (level == 4)
		{
			level++;
			Application.LoadLevel ("Ending");
		}
	}
}
