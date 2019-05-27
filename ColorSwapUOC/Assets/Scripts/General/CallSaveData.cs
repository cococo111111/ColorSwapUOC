using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSaveData : MonoBehaviour
{
public void SaveData()
    {
        LoadConfig.Instance.SaveDataGame();
    }
}
