using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Title : MonoBehaviour
{
    public string sceneName;
    public GameObject canvasObject;
    public Button ExitButton;
    public Button NewGameButton;

    void Start()
    {
        canvasObject = GameObject.Find("Canvas");

        Transform canvasTransform = canvasObject.transform;

        Transform NewGameButtonTransform = canvasTransform.Find("NewGameButton");
        Transform ExitButtonTransform = canvasTransform.Find("ExitButton");

        NewGameButton = NewGameButtonTransform.GetComponent<Button>();
        ExitButton = ExitButtonTransform.GetComponent<Button>();

        NewGameButton.onClick.AddListener(GameStart);
        ExitButton.onClick.AddListener(Exit);
    }

    void Update()
    {
        
    }

    
    public void GameStart()
    {   
        sceneName = "Testing";
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
