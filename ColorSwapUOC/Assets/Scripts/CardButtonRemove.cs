using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardButtonRemove : MonoBehaviour
{
    public int number;
    public int position;

    public void SendCardNumber()
    {
        BackPackMenu.Instance.RemoveCardToBackPack(number, position);
    }
}
