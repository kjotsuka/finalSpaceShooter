using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectGO : MonoBehaviour
{
    public GameObject LevelSelect;

    public Button levelSelectButton;

    // Use this for initialization
    void Start()
    {
        levelSelectButton = LevelSelect.GetComponent<Button>();

        levelSelectButton.onClick.AddListener(ToLevelSelect);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ToLevelSelect()
    {
        SceneManager.LoadScene(9);
    }

}
