using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;

    public TextMesh HighScore;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public TextMesh HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }
}
