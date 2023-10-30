using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    public InputField playerName;
    public Text messageArea;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerName()
    {
        PersistenceManager.Instance.playerName = playerName.text;
    }


    public void LoadMainScene()
    {
        if (playerName.text == "")
        {
            messageArea.text = "Please enter your name";
        } else
        {
            messageArea.text = "";
            SceneManager.LoadScene(1);
        }
    }


    public void ReturnToMenu()
    {
        PersistenceManager.Instance.SaveHighScore();
        SceneManager.LoadScene(0);
    }



    public void QuitGame()
    {
        PersistenceManager.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
