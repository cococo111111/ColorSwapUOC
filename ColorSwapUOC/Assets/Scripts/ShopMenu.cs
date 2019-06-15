using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public Text combis;
    public List<GameObject> cardsInventory = new List<GameObject>();
    public List<Sprite> spritesCards = new List<Sprite>();
    public GameObject inCombis;


    private void Awake()
    {
        inCombis.SetActive(false);
    }

    private void Start()
    {
        combis.text = GlobalInfo.coins;
        SetCards();
    }

    private void Update()
    {
        combis.text = GlobalInfo.coins;
    }

    public void Buy1000Points()
    {
        if(int.Parse(GlobalInfo.coins) >= 5000)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) - 5000).ToString();
            var newCard = GlobalInfo.cards[0] + 1;
            GlobalInfo.cards[0] = newCard;
            LoadConfig.Instance.SaveDataGame();
            SetCards();
        }
        else
        {
            inCombis.SetActive(true);
            StartCoroutine(Insuficient());
        }
    }

    public void BuyErase()
    {
        if (int.Parse(GlobalInfo.coins) >= 7000)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) - 7000).ToString();
            var newCard = GlobalInfo.cards[1] + 1;
            GlobalInfo.cards[1] = newCard;
            LoadConfig.Instance.SaveDataGame();
            SetCards();
        }
        else
        {
            inCombis.SetActive(true);
            StartCoroutine(Insuficient());
        }
    }

    public void BuyLevel1()
    {
        if (int.Parse(GlobalInfo.coins) >= 10000)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) - 10000).ToString();
            var newCard = GlobalInfo.cards[2] + 1;
            GlobalInfo.cards[2] = newCard;
            LoadConfig.Instance.SaveDataGame();
            SetCards();
        }
        else
        {
            inCombis.SetActive(true);
            StartCoroutine(Insuficient());
        }
    }

    public void Buy1Min()
    {
        if (int.Parse(GlobalInfo.coins) >= 15000)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) - 15000).ToString();
            var newCard = GlobalInfo.cards[3] + 1;
            GlobalInfo.cards[3] = newCard;
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_TIME_IS_MONEY);
            LoadConfig.Instance.SaveDataGame();
            SetCards();
        }
        else
        {
            inCombis.SetActive(true);
            StartCoroutine(Insuficient());
        }
    }

    public void BuyX2()
    {
        if (int.Parse(GlobalInfo.coins) >= 30000)
        {
            GlobalInfo.coins = (int.Parse(GlobalInfo.coins) - 30000).ToString();
            var newCard = GlobalInfo.cards[4] + 1;
            GlobalInfo.cards[4] = newCard;
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_LIKE_FLORENTINO);
            LoadConfig.Instance.SaveDataGame();
            SetCards();
        }
        else
        {
            inCombis.SetActive(true);
            StartCoroutine(Insuficient());
        }
    }

    IEnumerator Insuficient()
    {
        yield return new WaitForSeconds(2f);
        inCombis.SetActive(false);
    }

    public void SetCards()
    {
        for (var i=0; i < GlobalInfo.cards.Count; i++)
        {
            if (GlobalInfo.cards[i] > 0)
            {
                if(GlobalInfo.cards[i] > 1)
                {
                    cardsInventory[i].GetComponent<Image>().sprite = spritesCards[i];
                    cardsInventory[i].transform.GetChild(0).gameObject.SetActive(true);
                    cardsInventory[i].transform.GetChild(1).gameObject.SetActive(true);
                    cardsInventory[i].transform.GetChild(2).gameObject.SetActive(true);
                    cardsInventory[i].transform.GetChild(2).gameObject.GetComponentInChildren<Text>().text = GlobalInfo.cards[i].ToString();

                }
                else
                {
                    cardsInventory[i].GetComponent<Image>().sprite = spritesCards[i];
                    cardsInventory[i].transform.GetChild(0).gameObject.SetActive(true);
                    cardsInventory[i].transform.GetChild(1).gameObject.SetActive(true);
                    cardsInventory[i].transform.GetChild(2).gameObject.SetActive(false);
                }
            }
            else
            {
                cardsInventory[i].GetComponent<Image>().sprite = spritesCards[5];
                cardsInventory[i].transform.GetChild(0).gameObject.SetActive(false);
                cardsInventory[i].transform.GetChild(1).gameObject.SetActive(false);
                cardsInventory[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
}
