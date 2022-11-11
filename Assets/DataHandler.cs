using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Instance;

    public InputField InputField;
    private string PlayerNickname;

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
        public string PlayerNickname;

    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerNickname = PlayerNickname;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerNickname = data.PlayerNickname;
        }
    }
}
