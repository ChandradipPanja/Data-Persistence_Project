using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartMenuManager : MonoBehaviour
{
    public static StartMenuManager Instance;

    public string name;
    public int highestScore;
    public string currentPlayer;

    private void Awake()
    {
        //This pattern is called a singleton.
        //You use it to ensure that only a single instance of the MainManager can ever exist, so it acts as a central point of access.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //enables you to access the MainManager object from any other script. 
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    public class PlayerData
    {
        public string name;
        public int highestScore;
    }

    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData();
        playerData.name = name;
        playerData.highestScore = highestScore;

        string json = JsonUtility.ToJson(playerData);
        string filePath = @"E:\Unity Projects\GitHubProjects\Data-Persistence_Project\DummyJson\savePlayerData.json";
        File.WriteAllText(filePath, json);
    }

    public void LoadPlayerData()
    {
        string filePath = @"E:\Unity Projects\GitHubProjects\Data-Persistence_Project\DummyJson\savePlayerData.json";
        if(File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            name = playerData.name;
            highestScore = playerData.highestScore;
        }
    }


}

