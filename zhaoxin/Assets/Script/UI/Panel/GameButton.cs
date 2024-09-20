using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static TestSave;


public class GameButton : MonoBehaviour
{
    GameData data = new GameData();
    public Text id;
    public Image image;
    public Text place;
    public Text time;
    public GameObject haveData;
    public GameObject deleteButton;
    public Button StartButton;
    public string sceneName;
    private void Start()
    {
        Save();
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
        id.text = data.Id.ToString();
        place.text = data.place;
        time.text = data.time;
        sceneName = data.scene;
    }
    public void SavingData()
    {
        Debug.Log(id.text);
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
    public void LoadByJosn()
    {
        data = SaveSystem.LoadFromJSON<GameData>(id.text);
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
