using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;

public class ShowLeadersBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!GameServices.IsInitialized())
        {
            GameServices.Init();
        }
    }

    public void ShowLeaders()
    {
        GameServices.ShowLeaderboardUI();
    }
}
