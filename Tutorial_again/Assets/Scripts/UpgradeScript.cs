using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class UpgradeScript : MonoBehaviour
{
    //  public GameObject upgradeItem;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject fireRate;
    public GameObject moveSpeed;
    public GameObject hardenedBullets;
    public GameObject maxLives;


    public Button fireRateButton;
    public Button moveSpeedButton;
    public Button hardenedBulletsButton;
    public Button maxLivesButton;
    // public Button loginButton;


    public Text printThis;
    //public string Username;
    public Text UsernameText;
    // private string Username;
    // private string Password;
    int playerCurrency;

    public Text fireCost;
    public Text moveCost;
    public Text hardCost;
    public Text maxLivesCost;

    int move = 5000;
    int hardB = 10000;
    int fire = 200;
    int lives = 20000;

    int moveSel = 0;
    int hardSel = 0;
    int fireSel = 0;
    int livesSel = 0; 

    //
    //private string connectionString;

    // Use this for initialization
    void Start()
    {
        //   (FindObjectOfType<CurrentUser>().currentUser.setName());

        User player = GameObject.FindObjectOfType<CurrentUser>().currentUser;
        // prints the player's username
        UsernameText.text = "Username: " + (player.getName());

        // prints the player's Currency




       // FindObjectOfType<CurrentUser>().currentUser.setScore(50000);

        playerCurrency = (FindObjectOfType<CurrentUser>().currentUser.getCurrency());

     //   LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        printThis.text = "Player Currency: " + playerCurrency.ToString();

        //LoginScript.Save();



        fireRateButton = fireRate.GetComponent<Button>();
        moveSpeedButton = moveSpeed.GetComponent<Button>();
        hardenedBulletsButton = hardenedBullets.GetComponent<Button>();
        maxLivesButton = maxLives.GetComponent<Button>();


        fireCost.text = "Cost: " + fire.ToString();
        moveCost.text = "Cost: " + move.ToString();
        hardCost.text = "Cost: " + hardB.ToString();
        maxLivesCost.text = "Cost: " + lives.ToString();
        
        //


        fireRateButton.onClick.AddListener(SubtractFire);
        moveSpeedButton.onClick.AddListener(SubtractMove);
        hardenedBulletsButton.onClick.AddListener(SubtractHard);
        maxLivesButton.onClick.AddListener(SubtractMaxLives);

        //LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        // makes sure that when I log in I retain the info for currency
        PlayerPrefs.SetInt(player.getName(), playerCurrency);

    }

    // Update is called once per frame
    void Update()
    {


    }




    private void SubtractMove()
    {
        moveSel += 1;

        playerCurrency -= move;

        FindObjectOfType<CurrentUser>().currentUser.setCurrency(playerCurrency);

        printThis.text = "Player Currency: " + FindObjectOfType<CurrentUser>().currentUser.getCurrency().ToString();

        //        LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);

        FindObjectOfType<CurrentUser>().currentUser.setSpeed(moveSel);

        // PlayerPrefs.SetInt("playerMaxLives", );
    }

    private void  SubtractHard()
    {
        hardSel = 1;

        playerCurrency -= hardB;

        FindObjectOfType<CurrentUser>().currentUser.setCurrency(playerCurrency);

        printThis.text = "Player Currency: " + FindObjectOfType<CurrentUser>().currentUser.getCurrency().ToString();

        LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);

        PlayerPrefs.SetInt("Hard", hardSel);

       // FindObjectOfType<CurrentUser>().currentUser.set(moveSel);

    }

    

    private void SubtractFire()
    {
        

        //if(Username != "" && Password != "")
        {

            playerCurrency -= fire;


            FindObjectOfType<CurrentUser>().currentUser.setCurrency(playerCurrency);

          printThis.text = "Player Currency: " + FindObjectOfType<CurrentUser>().currentUser.getCurrency().ToString();

          //  FindObjectOfType<CurrentUser>().currentUser.setCurrency(player);

            //     UpdateScore(highScores[0].Username, newScore, 1);
            // print("you good nigga");
            //SceneManager.LoadScene(1);
        }
        // else
        //  {
        //     print("why nigga");
        // }

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);

        LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

       // PlayerPrefs.SetInt("playerCurrency", playerCurrency);


    }


    private void SubtractMaxLives()
    {
       livesSel = PlayerPrefs.GetInt("lives");

        livesSel += 1;

        PlayerPrefs.SetInt("lives", livesSel);

        playerCurrency -= lives;


        FindObjectOfType<CurrentUser>().currentUser.setCurrency(playerCurrency);

        printThis.text = "Player Currency: " + FindObjectOfType<CurrentUser>().currentUser.getCurrency().ToString();
       

        PlayerPrefs.SetInt(FindObjectOfType<CurrentUser>().currentUser.getName(), playerCurrency);

        FindObjectOfType<CurrentUser>().currentUser.setMaxHealth(livesSel);

        //   LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));

        // PlayerPrefs.SetInt("playerCurrency", playerCurrency);


    }


}
