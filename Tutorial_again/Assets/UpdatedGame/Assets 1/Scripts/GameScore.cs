using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour 
{
	Text scoreTextUI;

	int score;

	public int Score
	{
		get 
		{
			return this.score;
		}
		set 
		{
			this.score = value;
			UpdateScoreTextUI ();
		}
	}
	// Use this for initialization
	void Start () 
	{
		// get the Text UI component of this gameObject
		scoreTextUI = GetComponent<Text>();



       



      // User player = LoginScript.savedUsers.Find(user => user.getScore() == FindObjectOfType<CurrentUser>().currentUser.getScore());

        
        LoginScript.Save(FindObjectOfType<CurrentUser>().currentUser);

        // StoreCurrencyAndScore();
    }

 //   private void StoreCurrencyAndScore()
   // {
       // int fs =  PlayerPrefs.GetInt("finalScore");
        
 //   }

	// update score text UI
	void UpdateScoreTextUI()
	{
        int inc = 0;

		string scoreStr = string.Format ("{0:0000000}", score);
		scoreTextUI.text = scoreStr;



        FindObjectOfType<CurrentUser>().currentUser.setScore(score);

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName() + "Score", score);

        print(PlayerPrefs.GetInt(FindObjectOfType<CurrentUser>().currentUser.getName() + "Score") + "SCORE");

        int playerCurrency = FindObjectOfType<CurrentUser>().currentUser.getCurrency();

        int updatedCurrency = score + playerCurrency;

        print(score);

        FindObjectOfType<CurrentUser>().currentUser.setCurrency(updatedCurrency);

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), updatedCurrency);

        //PlayerPrefs.SetInt("finalScore", score);





        // PlayerPrefs.SetInt(player.getName(), playerCurrency);

        //    inc++;

        //      int p = Mathf.Max(inc);

        //     print(p);=

    }

}
