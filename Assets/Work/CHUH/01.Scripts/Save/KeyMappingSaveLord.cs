using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyMappingSaveLord : MonoBehaviour
{
    public KeyData KeyData;

    // 저장할때 호출
    public void SaveKeyDataToJson()
    {
        string jsonData = JsonUtility.ToJson(KeyData);
        string path = Path.Combine(Application.dataPath, "keyData.json");
        File.WriteAllText(path, jsonData);
    }

    // awake든 start든 이거 호출해서 값 복구
    public void LoadKeyDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "keyData.json");
        string jsonData = File.ReadAllText(path);
        KeyData = JsonUtility.FromJson<KeyData>(jsonData);
    }
}

[System.Serializable]
public class KeyData
{
    public string keyString;
}