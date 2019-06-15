using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    public void ShareSocial()
    {
        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_WHO_SHARES_DISTRIBUTES);
        Sharing.ShareText(this.GetComponentInChildren<Text>().text);
    }
}
