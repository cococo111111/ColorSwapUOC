using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardButton : MonoBehaviour
{
    public int number;

    public void SendCardNumber()
    {
        BackPackMenu.Instance.AddCardToBackPack(number);
    }


}
