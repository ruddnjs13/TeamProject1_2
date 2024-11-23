using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenScaleSaveLoad : MonoBehaviour
{
    public ScreenScaleData ScreenScaleData;

    // �����Ҷ� ȣ��
    public void SaveKeyDataToJson()
    {
        string jsonData = JsonUtility.ToJson(ScreenScaleData,true);
        string path = Path.Combine(Application.dataPath, "ScreenScaleData.json");
        File.WriteAllText(path, jsonData);
    }

    // awake�� start�� �̰� ȣ���ؼ� �� ����
    public void LoadKeyDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "ScreenScaleData.json");
        string jsonData = File.ReadAllText(path);
        ScreenScaleData = JsonUtility.FromJson<ScreenScaleData>(jsonData);
    }
}

[System.Serializable]
public class ScreenScaleData
{
    public int width;
    public int height;
    public int ScreenMode;
}
