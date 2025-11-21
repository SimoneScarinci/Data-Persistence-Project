using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string BestPlayerName;
    public int BestScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    private void Awake()
    {
        // Singleton: vogliamo una sola istanza che sopravvive tra le scene
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void TrySetNewBestScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            BestPlayerName = PlayerName;
            SaveScore();
        }
    }

    void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = BestPlayerName;
        data.score = BestScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }

    void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayerName = data.playerName;
            BestScore = data.score;
        }
    }
}
