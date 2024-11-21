using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyMappingSaveLord : MonoBehaviour
{
    public KeyData KeyData;

    // �����Ҷ� ȣ��
    public void SaveKeyDataToJson()
    {
        string jsonData = JsonUtility.ToJson(KeyData);
        string path = Path.Combine(Application.dataPath, "keyData.json");
        File.WriteAllText(path, jsonData);
    }

    // awake�� start�� �̰� ȣ���ؼ� �� ����
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