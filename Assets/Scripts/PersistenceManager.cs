using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public string playerName;
    public string highScorePlayer;
    public int highScore = 0;


    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighSCore();
    }



    [System.Serializable]
    class SaveData
    {
        public string highScoreplayerName;
        public int highScore = 0;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreplayerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighSCore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayer = data.highScoreplayerName;
            highScore = data.highScore;
        }
    }

}
