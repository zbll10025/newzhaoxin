using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class SaveSystem
{

    #region JSON

    public static void SaveByJSON(string saveFileName, object data)
    {
        var json = JsonUtility.ToJson(data);
        var path = Path.Combine(Application.persistentDataPath , saveFileName);

        try
        {
            File.WriteAllText(path, json);

#if UNITY_EDITOR
            Debug.Log($"Successfully save file to {path} . ");
#endif
        }
        catch (System.Exception exception)
        {

#if UNITY_EDITOR
            Debug.LogError($"Failed to save file to {path}\n {exception}");
#endif
        }
    }

    public static T LoadFromJSON<T>(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<T>(json);

            return data;
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to load file to {path}\n {exception}");
#endif
            return default;
        }
    }
    #endregion

    #region DELETE

    public static void DeleteFile(string saveFileName)
    {
        var path = Path.Combine(Application.persistentDataPath, saveFileName);

        try
        {
            File.Delete(path);
        }
        catch (System.Exception exception)
        {
#if UNITY_EDITOR
            Debug.LogError($"Failed to delete file to {path}\n {exception}");
#endif

        }
    }


    #endregion
}

