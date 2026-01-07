using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static MainManager Instance;

    public Color teamColor;
    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

        [System.Serializable]
      class SaveData
    {
            public Color teamColor; 
    }

        public void SaveColor()
        {
            SaveData data = new SaveData();
            data.teamColor = teamColor;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
        }

        public void LoadColor()
        {
            string path = Application.persistentDataPath + "/savedata.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                SaveData data = JsonUtility.FromJson<SaveData>(json);
                teamColor = data.teamColor;
            }
        }
    
}
