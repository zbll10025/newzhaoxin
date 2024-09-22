using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SaveObject : MonoBehaviour
{
    public GameData data;
    private Hero Player;
    private float time;
    private void Start()
    {
        Player = FindObjectOfType<Hero>();
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
    public bool LoadByJosn()
    {
        data = SaveSystem.LoadFromJSON<GameData>(Hero.startGameid.ToString());
        if (data != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void LoadData()
    {
        if (LoadByJosn())
        {
            time = ReturnTime(data.time);
        }
        else
        {
            time = 0f;
        }
    }
    public void SavingData()
    {
        Load();
        data = new GameData();
        data.Id = Hero.startGameid;
        data.place = SceneManager.GetActiveScene().name;
        time += Player.gameTime;
        data.time = GetFormattedPlayTime(time);
        data.scene = SceneManager.GetActiveScene().name;
        data.position = Player.transform.position;
        data.health = Player.health;
        data.GeoNum = Player.GeoNum;
        data.soulOrb = Player.soulOrbIndex;
    }

    public void SaveByJosn()
    {
        SaveSystem.SaveByJSON(Hero.startGameid.ToString(), data);
    }
    #region 存档点检测
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.F)&&collision.gameObject.CompareTag("SaveDetect"))
        {
            Save();
        }
    }
    #endregion
    #region 格式化时间
    public string GetFormattedPlayTime(float gameTime)
    {
        int hours = Mathf.FloorToInt(gameTime / 3600F);
        int minutes = Mathf.FloorToInt(gameTime / 60F);
        return string.Format("{0}H {1}M", hours, minutes);
    }
    public float ReturnTime(string timeString)
    {
        float totalSeconds = 0f;
        Match match = Regex.Match(timeString, @"(?<hours>\d+)H\s*(?<minutes>\d+)M");

        if (match.Success)
        {
            // 获取匹配的小时和分钟
            int hours = int.Parse(match.Groups["hours"].Value);
            int minutes = int.Parse(match.Groups["minutes"].Value);

            // 将小时和分钟转换为秒
           totalSeconds = (hours * 3600) + (minutes * 60);
        }
        return totalSeconds;
    }
    #endregion
    [System.Serializable]
    public class GameData
    {
        public int Id;
        public string place;
        public string time;
        public string scene;
        public Vector3 position;
        public int GeoNum;
        public int health;
        public int soulOrb;
    }
}
