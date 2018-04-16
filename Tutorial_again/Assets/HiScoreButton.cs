using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HiScoreButton : MonoBehaviour
{
    public GameObject HiScore;

    public Button HiScoresButton;

    // Use this for initialization
    void Start()
    {
        HiScoresButton = HiScore.GetComponent<Button>();

        HiScoresButton.onClick.AddListener(LoadHiScores);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHiScores()
    {
        SceneManager.LoadScene(4);
    }

}
