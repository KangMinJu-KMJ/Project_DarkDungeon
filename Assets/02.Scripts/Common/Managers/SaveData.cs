using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //폴더안의 파일의 존재유무 파악 후 불러오는 기능 지원

public class SaveData : MonoBehaviour
{
    private static SaveData instance = null;
    public string saveDataName = "Save.json";


    private void Awake()
    {
        if(instance = null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SaveData Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public GameData _gameData;
    public GameData gameData
    {
        get
        {
            if(_gameData == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + saveDataName;
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else
        {
            Debug.Log("새로운 파일 생성");
            _gameData = new GameData();
        }
    }

    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + saveDataName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장 완료");
    }

}
