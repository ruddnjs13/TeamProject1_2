using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test13 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SoundManager.Instance.PlaySfx(SFXEnum.뿅);
            Debug.Log(KeyMapping.Instance.RebindInfo);
            
        }
    }
}