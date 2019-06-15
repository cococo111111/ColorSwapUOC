using System;
using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using NiobiumStudios;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class MenuManager : MonoBehaviour
{

    public Text title;
    public Text message;
    //public GameObject dailyRewards;
    public Text totalCombis;
    public Text bestScore;
    public Text bestScoreOnline;
    public GameObject soundON;
    public GameObject soundOFF;
    bool soundGame;

    private void Awake()
    {
        //dailyRewards.SetActive(false);
        soundGame = true;
    }

    private void Start()
    {
        if (soundGame)
        {
            soundOFF.SetActive(true);
            soundON.SetActive(false);
            GlobalInfo.sound = false;
            soundGame = false;
        }
        if (!soundGame)
        {
            soundOFF.SetActive(false);
            soundON.SetActive(true);
            GlobalInfo.sound = true;
            soundGame = true;
        }
        if (!GameServices.IsInitialized())
        {
            GameServices.Init();
        }
        // Load a bestscore in AllTime time scope and Global user scope
        // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
        // of a leaderboard named "Sample Leaderboard"
        GameServices.LoadScores(EM_GameServicesConstants.Leaderboard_THE_BEST_COMBIX, 1, 1, TimeScope.AllTime, UserScope.Global, OnScoresLoaded);
        if (GlobalInfo.sessionsCount > 2)
        {
            Invoke("RateApp", 1.5f);
        }
      
        ScheduleRepeatLocalNotification();
        //NewInGame();
    }

    void RateApp()
    {
        Rating.Instance.RatingApp();
        GlobalInfo.sessionsCount = 0;
    }

    private void Update()
    {
        totalCombis.text = GlobalInfo.coins;
        bestScore.text = GlobalInfo.maxScore;
    }

    // Scores loaded callback
    void OnScoresLoaded(string leaderboardName, IScore[] scores)
    {
        if (scores != null && scores.Length > 0)
        {
            bestScoreOnline.text = scores[0].value.ToString();
            //foreach (IScore score in scores)
            //{
            //    bestScoreOnline.text = score.value.ToString();
            //}
        }
        else
        {
            bestScoreOnline.text = "0";
        }
    }

    // Construct the content of a new notification for scheduling.
    NotificationContent PrepareNotificationContent()
{
    NotificationContent content = new NotificationContent();

    // Provide the notification title.
    content.title = title.text;

    // You can optionally provide the notification subtitle, which is visible on iOS only.
    content.subtitle = "Demo Subtitle";

    // Provide the notification message.
    content.body = message.text;

    // You can optionally attach custom user information to the notification
    // in form of a key-value dictionary.
    content.userInfo = new Dictionary<string, object>();
    content.userInfo.Add("string", "OK");
    content.userInfo.Add("number", 3);
    content.userInfo.Add("bool", true);

        // You can optionally assign this notification to a category using the category ID.
        // If you don't specify any category, the default one will be used.
        // Note that it's recommended to use the category ID constants from the EM_NotificationsConstants class
        // if it has been generated before. In this example, UserCategory_notification_category_test is the
        // generated constant of the category ID "notification.category.test".
        content.categoryId = EM_NotificationsConstants.UserCategory_combix_category;

    // If you want to use default small icon and large icon (on Android),
    // don't set the smallIcon and largeIcon fields of the content.
    // If you want to use custom icons instead, simply specify their names here (without file extensions).
    //content.smallIcon = "YOUR_CUSTOM_SMALL_ICON";
    //content.largeIcon = "YOUR_CUSTOM_LARGE_ICON";

    return content;
}

    void ScheduleRepeatLocalNotification()
    {
        // Prepare the notification content (see the above section).
        NotificationContent content = PrepareNotificationContent();

        // Set the delay time as a TimeSpan.
        TimeSpan delay = new TimeSpan(23, 45, 01);

        // Schedule the notification.
        Notifications.ScheduleLocalNotification(delay, content, NotificationRepeat.EveryDay);
    }
    public void Sound()
    {
        if (soundGame)
        {
            soundOFF.SetActive(true);
            soundON.SetActive(false);
            GlobalInfo.sound = false;
        }
        if (!soundGame)
        {
            soundOFF.SetActive(false);
            soundON.SetActive(true);
            GlobalInfo.sound = true;
        }
        soundGame = !soundGame;
    }
}
