using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;
    void Awake()
    {
        Instance = this;
        if (!RuntimeManager.IsInitialized())
            RuntimeManager.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        ShowBannerAds();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowBannerAds()
    {
        Advertising.ShowBannerAd(BannerAdPosition.Bottom);
    }

    public void ShowInterstitalAds()
    {
        if (Advertising.IsInterstitialAdReady())
        {
            Advertising.ShowInterstitialAd();
        }
    }

    public void ShowRewardedAds()
    {
        if (Advertising.IsRewardedAdReady())
        {
            Advertising.ShowRewardedAd();
        }
    }
}
