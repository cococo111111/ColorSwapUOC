using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using NiobiumStudios;
using UnityEngine;

public class Rewards : MonoBehaviour
{

    bool oneTime = true;

    private void Start()
    {
        InvokeRepeating("SetOneTime", 0f, 3.0f);
    }

    void SetOneTime()
    {
        if (!oneTime)
        {
            oneTime = true;
        }

    }

    void OnEnable()
    {
        DailyRewards.GetInstance().onClaimPrize += OnClaimPrizeDailyRewards;
    }

    void OnDisable()
    {
        Debug.Log("AQUI ON DISABLE");
        DailyRewards.GetInstance().onClaimPrize -= OnClaimPrizeDailyRewards;
    }

    // this is your integration function. Can be on Start or simply a function to be called
    public void OnClaimPrizeDailyRewards(int day)
    {
        //This returns a Reward object
        Reward myReward = DailyRewards.GetInstance().GetReward(day);

        // And you can access any property
        //print(myReward.unit);   // This is your reward Unit name
        //print(myReward.reward); // This is your reward count
        //Debug.Log(int.Parse(GlobalInfo.coins));
        if (myReward.unit == "1 MIN" && oneTime)
        {
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_FIDELITY);
            var newCard = GlobalInfo.cards[3] + 1;
            GlobalInfo.cards[3] = newCard;
            LoadConfig.Instance.SaveDataGame();
            oneTime = false;
        }
        else if (oneTime)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) + myReward.reward).ToString();
            Debug.Log(GlobalInfo.coins);
            LoadConfig.Instance.SaveDataGame();
            oneTime = false;
        }
    }
}
