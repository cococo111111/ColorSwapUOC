using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public static CardsManager Instance;
    public static int numberCards;
    public GameObject coinsCard;
    public GameObject x2Card;
    public GameObject oneMinCard;
    public GameObject eraserCard;
    public GameObject level1Card;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        TakeTheCards();
    }

    void TakeTheCards()
    {
        //Comprobem les cartas que hi han a la motxila
    }

    public void ActionCard(string card)
    {
        if (card == coinsCard.name)
        {
            GameManager.Instance.ParticleCardsPoints(5, 1000);
        }
        if (card == x2Card.name)
        {
            GlobalInfo.score = GlobalInfo.score * 2;
        }
        if (card == oneMinCard.name)
        {
            GameManager.timer = GameManager.timer + 60;
        }
        if (card == eraserCard.name)
        {
            GameManager.Instance.ClearGrid();
        }
        if (card == level1Card.name)
        {
            GlobalInfo.speed = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
