using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class LevelScript : MonoBehaviour
{
    //  public GameObject upgradeItem;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;


    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;

    // public Button loginButton;


 //   public Text printThis;
    //public string Username;
 //   public Text UsernameText;
    // private string Username;
    // private string Password;
 //   int playerCurrency;

    //
    //private string connectionString;

    // Use this for initialization
    void Start()
    {



        level1Button = level1.GetComponent<Button>();
        level2Button = level2.GetComponent<Button>();
        level3Button = level3.GetComponent<Button>();
        level4Button = level4.GetComponent<Button>();



        //


        level1Button.onClick.AddListener(LoadLevel1);
        level2Button.onClick.AddListener(LoadLevel2);
        level3Button.onClick.AddListener(LoadLevel3);
        level4Button.onClick.AddListener(LoadLevel4);

        //LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        // makes sure that when I log in I retain the info for currency
     //   PlayerPrefs.SetInt(player.getName(), playerCurrency);

    }

    // Update is called once per frame
    void Update()
    {
        //  fireRateButton.onClick.AddListener(SubtractScore);
        // GetUserData();
        //LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));
        // SubtractScore();
        //  SubtractScore();

    }





    private void GetUserData()
    {
        //  UpdateScore(highScores[0].Username, highScores[0].Score, 1);

        //  highScores.Sort();

    }

  
    private void LoadLevel1()
    {
        SceneManager.LoadScene(3);

      //  LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

      //  PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);
    }



    private void LoadLevel2()
    {
       // int fire = 200;

        //if(Username != "" && Password != "")
        {

            
            //  FindObjectOfType<CurrentUser>().currentUser.setCurrency(player);

            //     UpdateScore(highScores[0].Username, newScore, 1);
            // print("you good nigga");
            SceneManager.LoadScene(5);
        }
        // else
        //  {
        //     print("why nigga");
        // }

    //    PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);

//        LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));



    }


    private void LoadLevel3()
    {
        SceneManager.LoadScene(6);

        //  LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        //  PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);
    }

    private void LoadLevel4()
    {
        SceneManager.LoadScene(7);

        //  LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        //  PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);
    }


}
