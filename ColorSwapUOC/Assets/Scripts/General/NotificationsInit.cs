using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationsInit : Singleton<NotificationsInit>
{
    private void Start()
    {
        Notifications.Init();
    }
}
