using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundSettingSaveLoad : MonoBehaviour
{
    public SoundData SoundData;

    private string path = Path.Combine(Application.dataPath, "soundData.json");

    private void Awake()
    {
        if (!File.Exists(path))
        {
            Debug.Log("���̸�����");
            string jsonData = JsonUtility.ToJson(SoundData, true);
            File.WriteAllText(path, jsonData);
        }
    }

    // �����Ҷ� ȣ��
    public void SaveSoundDataToJson()
    {
        string jsonData = JsonUtility.ToJson(SoundData,true);
        File.WriteAllText(path, jsonData);
    }

    // awake�� start�� �̰� ȣ���ؼ� �� ����
    public void LoadSoundDataFromJson()
    {
        string jsonData = File.ReadAllText(path);
        SoundData = JsonUtility.FromJson<SoundData>(jsonData);
    }
}

[System.Serializable]
public class SoundData
{
    public float MasterSoundScale;
    public float SFXSoundScale;
    public float BGMSoundScale;

}
