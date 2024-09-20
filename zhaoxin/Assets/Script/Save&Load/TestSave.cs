using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    TestData data = new TestData();
    public int id;
    public string _name;
    public Vector3 position;

    public void Start()
    {
       
        Load();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }
    }
    public void Save()
    {
        SavingData();
        SaveByJosn();
    }
    public void Load()
    {
        LoadByJosn();
        LoadData();

    }
    public void LoadData()
    {

        id = data.Id;
        _name = data.name;
        position = data.position;
    }
    public void SavingData()
    {
        data.Id = id;
        data.position = position;
        data.name = _name;
    }
    public void SaveByJosn()
    {
        SaveSystem.SaveByJSON(_name, data);
    }
    public void LoadByJosn()
    {
      data = SaveSystem.LoadFromJSON<TestData>(_name);
    }
    [System.Serializable]
    public class TestData
    {
        public int Id;
        public string name;
        public Vector3 position;

    }
}