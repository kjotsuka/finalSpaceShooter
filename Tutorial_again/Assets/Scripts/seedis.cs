using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seedis : MonoBehaviour
{

    /*

    public Text CurrencyText, OtherText;

    // string username = "BigDickLick";
   string arg0;

    // PlayerPrefs is the way to access a kind of User class where you set string and float 

    private void Update()
    {
        
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
       // PlayerPrefs.SetString("Username", arg0);
        //OtherText.text = PlayerPrefs.GetString("Username");
    }

    public void Awake()
    {

       

     //   PlayerPrefs.SetString("Username", username);

        CurrencyText.text = "Currency:" + (PlayerPrefs.GetInt("Currency").ToString());

        PlayerPrefs.SetInt("Currency", 75000);

        //   OtherText.text = (PlayerPrefs.GetString("Username").ToString());
        Update();
    }

    private void SubmitName(string arg0)
    {
        // Debug.Log(arg0);
      //  PlayerPrefs.SetString("Username", arg0);
      // OtherText.text = PlayerPrefs.GetString("Username");
      // this is where I would want to get the username data 
      // submitName string arg0 is actually the input string 

    }

    */

    /// ///////////////////////

    //   public class VariablesAndFunctions : MonoBehaviour
    //  {
    ///     int myInt = 5;


    ///        void Start()
    //p     {
    //          myInt = MultiplyByTwo(myInt);
    //         Debug.Log(myInt);
    //     }


    //     var myInt : int = 5;




    //function Start()
    //      {
    //         myInt = MultiplyByTwo(myInt);
    ///        Debug.Log(myInt);
    //  }


    /// ////////////////////////////////////////////////////

    //      function MultiplyByTwo(number : int) : int
    //{
    //   var ret : int;
    // ret = number* 2;
    //return ret;
    //}




   public Text NameDisplay;

   string PlayerNAME = "";
   string SavedNAME;
 
 void Start()
    {
        SavedNAME = PlayerPrefs.GetString("Stored Name", PlayerNAME);

        if (SavedNAME != null)
        {
            print(SavedNAME);
            PlayerNAME = SavedNAME; // show the current SavedNAME in the GUI.TextArea
        }
    }

    void OnGUI()
    {
     //   NameDisplay.text= PlayerNAME;

        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        PlayerNAME = GUI.TextArea(new Rect(65, 10, 100, 25), PlayerNAME, 10);

        if (GUI.Button(new Rect(10, 70, 50, 30), "Click"))
        {
            SaveName(PlayerNAME);
        }

        // Show the Current SavedNAME
        GUI.Box(new Rect((Screen.width / 2) - 100, 10, 200, 30), "Hello " + SavedNAME); // Text in Box
                                                                                        // GUI.Label(Rect((Screen.width/2)-100, 10, 200, 30), "Hello " + SavedNAME); // Text as Label
        
    }

    void SaveName(string PlayerNAME)
    {
        PlayerPrefs.SetString("Stored Name", PlayerNAME);
        SavedNAME = PlayerNAME; // reset SavedNAME to the PlayerNAME from GUI.TextArea and GUI.Button
    }







}
