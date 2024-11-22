using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SoundSettingSaveLoad : MonoBehaviour
{
    public SoundData SoundData;

    // 저장할때 호출
    public void SaveSoundDataToJson()
    {
        string jsonData = JsonUtility.ToJson(SoundData);
        string path = Path.Combine(Application.dataPath, "soundData.json");
        File.WriteAllText(path, jsonData);
    }

    // awake든 start든 이거 호출해서 값 복구
    public void LoadSoundDataFromJson()
    {
        string path = Path.Combine(Application.dataPath, "soundData.json");
        string jsonData = File.ReadAllText(path);
        SoundData = JsonUtility.FromJson<SoundData>(jsonData);
    }
}

[System.Serializable]
public class SoundData
{
    public float MasterSoundScale;
    public float SFXSoundScale;
    public float BFMSoundScale;

}
