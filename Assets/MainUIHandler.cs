using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    public Text playerName;
    private Text highScoreText;

    private void Awake()
    {
        DataHandler.Instance.LoadHighScore();
    }

    private void Start()
    {
        if (DataHandler.Instance != null)
        {
            playerName.text = DataHandler.Instance.Input.text;
            highScoreText.text = $"Score : {playerName.text} : {DataHandler.Instance.highScore}";
        }
    }
}
