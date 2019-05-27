﻿using System;
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
    public GameObject dailyRewards;
    public Text totalCombis;
    public Text bestScore;
    public Text bestScoreOnline;

    private void Awake()
    {
        dailyRewards.SetActive(false);
    }

    private void Start()
    {
        // Load a bestscore in Today time scope and Global user scope
        // EM_GameServicesConstants.Sample_Leaderboard is the generated name constant
        // of a leaderboard named "Sample Leaderboard"
        GameServices.LoadScores(EM_GameServicesConstants.Leaderboard_THE_BEST_COMBIX, 0, 10, TimeScope.AllTime, UserScope.Global, OnScoresLoaded);

        Rating.Instance.RatingApp();
        Notifications.Init();
        ScheduleRepeatLocalNotification();
        NewInGame();
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
            foreach (IScore score in scores)
            {
                bestScoreOnline.text = score.value.ToString() +" "+ score.rank +" "+ scores.Length.ToString();
            }
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
    content.categoryId = EM_NotificationsConstants.UserCategory_UserCategory_notification_category_test;

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
        TimeSpan delay = new TimeSpan(08, 08, 08);

        // Schedule the notification.
        Notifications.ScheduleLocalNotification(delay, content, NotificationRepeat.EveryDay);
    }

    void NewInGame()
    {
        if (GlobalInfo.gameFirstTime == "true")
        {
            //Accionar la pantalla de kit inicial
            Debug.Log("NEW IN GAME");
        }
    }

    public void LaunchDailyRewards()
    {
        dailyRewards.SetActive(true);
    }
}