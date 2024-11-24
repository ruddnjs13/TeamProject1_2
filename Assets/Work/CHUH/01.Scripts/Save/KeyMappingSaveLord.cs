using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class KeyMappingSaveLord : MonoBehaviour
{
    public KeyData KeyData;

    private string path = Path.Combine(Application.dataPath, "keyData.json");


    private void Awake()
    {
        if (!File.Exists(path))
        {
            Debug.Log("���̸�����");
            string jsonData = JsonUtility.ToJson(KeyData, true);
            File.WriteAllText(path, jsonData);
        }
    }

    // �����Ҷ� ȣ��
    public void SaveKeyDataToJson()
    {
        string jsonData = JsonUtility.ToJson(KeyData,true);
        File.WriteAllText(path, jsonData);
    }

    // awake�� start�� �̰� ȣ���ؼ� �� ����
    public void LoadKeyDataFromJson()
    {
        string jsonData = File.ReadAllText(path);
        KeyData = JsonUtility.FromJson<KeyData>(jsonData);
    }
}

[System.Serializable]
public class KeyData
{
    public string keyString;
}