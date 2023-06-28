using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public static string currentPlayer = string.Empty;
    public static KeyValuePair<string, int> highscore;

    const string fileExt = "/highscore.txt";

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        LoadInfo();
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        SaveInfo();
    }

    void LoadInfo()
    {
        string filepath = Application.persistentDataPath + fileExt;
        if (File.Exists(filepath))
        {
            string[] fromFile = File.ReadAllLines(filepath);
            highscore = new KeyValuePair<string, int>(fromFile[0], int.Parse(fromFile[1]));
        }
    }

    void SaveInfo()
    {
        string filepath = Application.persistentDataPath + fileExt;
        if (File.Exists(filepath)) File.Delete(filepath);

        FileStream fs = File.Create(filepath);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(highscore.Key);
        sw.WriteLine(highscore.Value.ToString());
        sw.Close();
        fs.Close();
    }
}
