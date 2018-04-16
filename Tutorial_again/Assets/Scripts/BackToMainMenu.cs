using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public GameObject Back;

    public Button backButton;

    // Use this for initialization
    void Start()
    {
        backButton = Back.GetComponent<Button>();

        backButton.onClick.AddListener(BackToMain);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BackToMain()
    {
        SceneManager.LoadScene(1);
    }

}
