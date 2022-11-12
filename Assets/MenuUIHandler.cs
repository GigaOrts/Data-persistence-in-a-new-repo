using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text HighScoreText;
    public static InputField playerInputField;

    public string playerInput;

    private void Start()
    {
        DataHandler.Instance.LoadHighScore();
        HighScoreText.text = $"HighSoore: {DataHandler.Instance.highScore}";
    }

    public void SaveInputName()
    {
        playerInput = playerInputField.textComponent.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataHandler.Instance.SaveHighScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
