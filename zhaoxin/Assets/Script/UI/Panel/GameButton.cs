using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TestSave;


public class GameButton : MonoBehaviour
{
    public GameData data = new GameData();
    public Text id;
    public Image image;
    public Text place;
    public Text time;
    public GameObject haveData;
    public GameObject deleteButton;
    public Button StartButton;
    public string sceneName;
    private void Awake()
    {
        Load();
    }
    public void Load()
    {

        LoadByJosn();
        LoadData();
        
    }
    public void Save()
    {
        SavingData();
        SaveByJosn();
    }
    public void LoadData()
    {
        if(LoadByJosn())
        {
            place.text = data.place;
            time.text = data.time;
            sceneName = data.scene;
        }
        else
        {
            place.text = "";
            time.text = "";
            sceneName = "";
        }
    }
    public void SavingData()
    {
        int mun = int.Parse(id.text);//תintֵ
        data.Id = mun;
        data.place = place.text;
        data.time = time.text;
        data.scene = place.text;
    }
    public void SaveByJosn()
    {
        SaveSystem.SaveByJSON(id.text, data);
    }
    public bool LoadByJosn()
    {
        data = SaveSystem.LoadFromJSON<GameData>(id.text);
        if(data != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    [System.Serializable]
    public class GameData
    {
        public int Id;
        public string place;
        public string time;
        public string scene;
        
    }
}
