using System.Collections;
using System.Collections.Generic;
using NiobiumStudios;
using UnityEngine;

public class Rewards : MonoBehaviour
{

    bool oneTime;

    private void Start()
    {
        oneTime = true;
    }

    void OnEnable()
    {
        Debug.Log("AQUI ON ENABLE");
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
            Debug.Log("AQUI CARD");
            GlobalInfo.cards.Add(myReward.unit);
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
