// 0_Core/Data/SaveSystem.cs
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private string _savePath => Path.Combine(Application.persistentDataPath, "save.json");

    public void SaveGame()
    {
        var saveData = new SaveData
        {
            Resources = GameManager.Instance.ResourceManager.GetSaveData(),
            Time = GameManager.Instance.TimeManager.GetSaveData(),
            Provinces = GameManager.Instance.ProvinceManager.GetSaveData()
        };

        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(_savePath, json);
    }

    public void LoadGame()
    {
        if (!File.Exists(_savePath)) return;

        string json = File.ReadAllText(_savePath);
        SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

        GameManager.Instance.ResourceManager.LoadData(saveData.Resources);
        GameManager.Instance.TimeManager.LoadData(saveData.Time);
        GameManager.Instance.ProvinceManager.LoadData(saveData.Provinces);
    }
}

[System.Serializable]
public class SaveData
{
    public ResourceSaveData Resources;
    public TimeSaveData Time;
    public ProvinceSaveData[] Provinces;
}