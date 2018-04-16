using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


    public class HighScores : MonoBehaviour {

    // private string connectionString;

    private static List<User> highScores;
    // private List<User>  = new List<User>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks;

   public Text printThis;

    public Text printMe;

    int playerCurrency;
    // Use this for initialization
    void Start ()
    {

        highScores = new List<User>();

      //  Load();


        // this prints all of the users in the file created on the platform
        LoginScript.savedUsers.ForEach(user => print(user.getName()));



        LoginScript.savedUsers.ForEach(user => print(user.getCurrency()));


        playerCurrency = (FindObjectOfType<CurrentUser>().currentUser.getCurrency());
        printMe.text = playerCurrency.ToString();


        
        //  LoginScript.savedUsers.ForEach(print);

        int count = LoginScript.savedUsers.Count;

        LoginScript.savedUsers.Sort();

        if (count < topRanks)
            topRanks = count;

        for (int i = 0; i < topRanks; i++)
        {
            GameObject tempObject = Instantiate(scorePrefab);

            User tempScore = LoginScript.savedUsers[i];

            tempObject.GetComponent<HighScoreScrript>().SetScore(tempScore.getName(), tempScore.getScore().ToString(), "#" + (i + 1).ToString());

            tempObject.transform.SetParent(scoreParent);

            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }


        // this game object stores the instance of the current user 
        //print(GameObject.FindObjectOfType<CurrentUser>().currentUser.getName());

        printThis.text = (FindObjectOfType<CurrentUser>().currentUser.getName());

        // LoginScript.savedUsers.Sort();


        FindObjectOfType<CurrentUser>().currentUser.setCurrency(50000);

        // User.getName();

    }


    /*
    private static string filename;

    public static void Load()
    {
        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filename, FileMode.Open);
            // if there is no file, create an empty list of users
            if (file.Length == 0)
                highScores = new List<User>();
            else
                highScores = (List<User>)bf.Deserialize(file);
            file.Close();
        }
    }
    */
    // Update is called once per frame
    void Update ()
    {
		
	}


   // public void EnterUsername()
 //   {
  //      if((enterUsername.text != string.Empty))
   ///     {
     //       int score = 789;
        //    InsertScore(enterUsername.text, score, 0);
    //        enterUsername.text = string.Empty;
     //   }

    //}


    

    //
       

    }

   
       // GetScores();
     /*   for(int i = 0; i < topRanks; i++)
        {
            GameObject tempObject =  Instantiate(scorePrefab);


            // change this to User class
            HighScore tempScore = highScores[i];

            tempObject.GetComponent<HighScoreScrript>().SetScore(tempScore.Username, tempScore.Score.ToString(), "#" + (i+1).ToString());

            tempObject.transform.SetParent(scoreParent);

            tempObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

        

    }

    */


   


//}
