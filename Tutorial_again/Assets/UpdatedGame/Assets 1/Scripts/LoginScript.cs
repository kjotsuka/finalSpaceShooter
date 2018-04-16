using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//using System.Data;
//using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class LoginScript : MonoBehaviour
{
    // might  be private
    public static List<User> savedUsers;

    public GameObject createUser;

    public Button createUserButton;

    public GameObject LoginUser;

    public Button LoginUserButton;

    public string profileString = string.Empty;

    private List<User> highScores = new List<User>();

    // public GameObject scorePrefab;

    // public Transform scoreParent;

    // public int topRanks;

    public Text enterUsername;

    FileStream file;

    private static string filename;

    int pf;

    // Use this for initialization
    void Start()
    {
        filename = Application.persistentDataPath + "/savedGames2.gd";
        // if persistent data file for saved games does not exist, make one
        if (!(File.Exists(filename)))
            file = File.Create(filename);

        savedUsers = new List<User>();

       // createUserButton.onClick.AddListener(LoadMainMenu);
        
      //  if(enterUsername.text != String.Empty)
             LoginUserButton.onClick.AddListener(LoadMainMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Login()
    {

        Load();
        // Attempt to find a user by the username entered.

        PlayerPrefs.SetString("Username", enterUsername.text);

        print("enterUsername: " + enterUsername.text + 
                "\nsavedUsers == null" + (savedUsers == null) +
                "\n");
        User player = LoginScript.savedUsers.Find(user => user.getName() == enterUsername.text);

        //LoginScript.savedUsers.Clear();

        if (player == null)
        {
            print("RETARD SCREECH!!!");
            pf = 1;
        }

        // If player was found, set user.
        if (player != null)
        {
            FindObjectOfType<CurrentUser>().currentUser = player;
            //profileString = "Found " +  currentUser.currentUser.getName() + "\nLevel: " + currentUser.currentUser.getLevel() +
            //	"\nCurrency: " + currentUser.currentUser.getCurrency() + "\nScore: " + currentUser.currentUser.getScore();	
            profileString =
            "Found " + player.getName() +
                " Level: " + player.getLevel() +
               // " Currency: " +//player.getCurrency() +
               // +
                " Score: " + player.getScore();

            print(profileString);


            savedUsers.ForEach(user => print(user.getName()));




           // int updatedScore = PlayerPrefs.GetInt(player.getName() + "Score");

            //if(updatedScore < player.getScore())
            //{
             //   updatedScore = player.getScore();
            //}

         //   player.setScore(updatedScore);


            //  Save(FindObjectOfType<CurrentUser>().currentUser);

            savedUsers.ForEach(user => print(user.getScore()));

            // this makes sure we load the proper currency from last time 
            int cur = PlayerPrefs.GetInt(enterUsername.text);

            player.setCurrency(cur);

            print(FindObjectOfType<CurrentUser>().currentUser.getCurrency());

            savedUsers.ForEach(user => print(user.getCurrency()));

            //  SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }


    }

    // might be private
    public static void Load()
    {
        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filename, FileMode.Open);
            // if there is no file, create an empty list of users
            if (file.Length == 0)
                LoginScript.savedUsers = new List<User>();
            else
                LoginScript.savedUsers = (List<User>)bf.Deserialize(file);
            file.Close();
        }
    }
    // possibly private
    // This function does not verify if a user is duplicated
    // That must be done by the caller if duplicates are to be avoided
    public static void Save(User user)
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames2.gd"))
        {
            Load();
            LoginScript.savedUsers.Add(user);
            BinaryFormatter bf = new BinaryFormatter();
            //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames2.gd", FileMode.Open); //you can call it anything you want
            bf.Serialize(file, LoginScript.savedUsers);
            file.Close();
        }
    }





    public void RegisterUser()
    {
        Load();

        // Attempt to find a user with the same name from currently regisetered users.
        User player = LoginScript.savedUsers.Find(user => user.getName() == enterUsername.text);

        // If a valid username is entered, and a user with the same name is not found, create new user.
        if (enterUsername.text != String.Empty && player == null)
        {
            User user = new User(enterUsername.text);
            Save(user);
            //profileString = 
            print("Registered New User: " + enterUsername.text);
        }
        // If a user with same username is entered, indicate.
        else
        {
          print("Could not register: " + enterUsername.text);
        }

       // enterUsername.text = string.Empty;
    }


    //private void GetUserData()
    //{
      
    //}

  //  public void EnterUsername()
   // {
    //    if ((enterUsername.text != string.Empty))
     //   {
          //  PlayerPrefs.SetString(enterUsername.text, enterUsername.text);
           // int score = 4343;
           // InsertScore(enterUsername.text, score, 1);
           // enterUsername.text = string.Empty;
      //  }

//    }

 



    private void LoadMainMenu()
    {
       // int pf;

        if((enterUsername.text != String.Empty) && pf!=1)
      //  {

        //    print(PlayerPrefs.GetString("BigDickLick"));
        //    print(username.GetComponent<InputField>().text);
            // PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(1);
      //  }

    }



}
