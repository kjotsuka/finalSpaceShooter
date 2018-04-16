using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeUserScript : MonoBehaviour
{
    public GameObject changeUser;

    public Button changeButton;

    // Use this for initialization
    void Start ()
    {
        changeButton = changeUser.GetComponent<Button>();

        changeButton.onClick.AddListener(BackToLogin);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void BackToLogin()
    {
        SceneManager.LoadScene(0);
    }

}
