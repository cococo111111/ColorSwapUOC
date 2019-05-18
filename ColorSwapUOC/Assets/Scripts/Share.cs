using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    public void ShareSocial()
    {
        Sharing.ShareText(this.GetComponentInChildren<Text>().text);
    }
}
