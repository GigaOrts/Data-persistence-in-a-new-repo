using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    private Text highScoreText;
    private string playerInput;

    private void Awake()
    {
        DataHandler.Instance.LoadHighScore();
        playerInput = DataHandler.Instance.playerInput;
    }

    private void Start()
    {
        if (DataHandler.Instance != null)
        {
            
            int highScore = DataHandler.Instance.highScore;

            highScoreText.text = $"Score : {playerInput} : {highScore}";
        }
    }
}
