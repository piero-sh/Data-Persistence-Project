using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager
{
    private static GameManager _Instance;
    public static GameManager Instance
    { 
        get
        {
            //not thread safe. Enough for this use case being a tuto.
            if(_Instance == null)
            {
                _Instance = new GameManager();
            }
            return _Instance;
        }
    }

    public string playerName;
    private BestScore _bestScore;
    public BestScore bestScore
    { 
        get
        {
            if(_bestScore == null)
            {
                _bestScore = new BestScore();
            }
            return _bestScore;
        }
        private set
        {
            _bestScore = value;
        }
    }
    private string bestScorePath = Application.persistentDataPath + "/bestscore.json";

    public void LoadBestScore()
    {
        if(File.Exists(bestScorePath))
        {
            string jsonFile = File.ReadAllText(bestScorePath);
            bestScore = JsonUtility.FromJson<BestScore>(jsonFile);
        }
    }

    private void SaveBestScore()
    {
        string jsonFile = JsonUtility.ToJson(bestScore);
        File.WriteAllText(bestScorePath, jsonFile);
    }

    public bool NewBestScore(string name, int score)
    {
        if(score > bestScore.score)
        {
            bestScore.name = name;
            bestScore.score = score;
            SaveBestScore();
            return true;
        }
        return false;
    }

    [Serializable]
    public class BestScore
    {
        public string name;
        public int score;
    }
}
