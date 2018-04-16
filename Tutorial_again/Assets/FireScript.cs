using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;

public class FireScript : MonoBehaviour
{

   public InputField Email;

    public InputField Password;

    public void LoginButtonPressed()
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(Email.text, Password.text).ContinueWith((obj) =>
        {
            SceneManager.LoadSceneAsync(1);
        });
    }

    public void CreateNewUserButtonPressed()
    {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(Email.text, Password.text).ContinueWith((obj) =>
        {
            SceneManager.LoadSceneAsync(1);
        });


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
