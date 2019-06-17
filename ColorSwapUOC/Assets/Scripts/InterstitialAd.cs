using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;

public class InterstitialAd : MonoBehaviour
{
    void Awake()
    {
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();
    }

    void OnEnable()
    {
        Advertising.RewardedAdCompleted += RewardedAdCompletedHandler;
        Advertising.RewardedAdSkipped += RewardedAdSkippedHandler;
    }

    // Unsubscribe events
    void OnDisable()
    {
        Advertising.RewardedAdCompleted -= RewardedAdCompletedHandler;
        Advertising.RewardedAdSkipped -= RewardedAdSkippedHandler;
    }

    // Event handler called when a rewarded ad has completed
    void RewardedAdCompletedHandler(RewardedAdNetwork network, AdPlacement location)
    {
        Debug.Log("Rewarded ad has completed. The user should be rewarded now.");
        GlobalInfo.coins = (int.Parse(GlobalInfo.coins) + 10000).ToString();
        LoadConfig.Instance.SaveDataGame();
    }

    // Event handler called when a rewarded ad has been skipped
    void RewardedAdSkippedHandler(RewardedAdNetwork network, AdPlacement location)
    {
        Debug.Log("Rewarded ad was skipped. The user should NOT be rewarded.");
    }

    public void LaunchVideo()
    {
        // Check if rewarded ad is ready
        bool isReady = Advertising.IsRewardedAdReady();
        // Show it if it's ready
        if (isReady)
        {
            Advertising.ShowRewardedAd();
        }
    }
}
