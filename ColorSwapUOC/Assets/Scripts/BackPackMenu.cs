using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackMenu : MonoBehaviour
{
    public static BackPackMenu Instance;
    public List<GameObject> cardsInventory = new List<GameObject>();
    public List<GameObject> cardsBackPack = new List<GameObject>();
    public List<Sprite> spritesCards = new List<Sprite>();

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetCardsBackPack();
    }


    // Update is called once per frame
    void Update()
    {
        SetCardsInventory();
    }

    public void SetCardsInventory()
    {
        for (var i = 0; i < GlobalInfo.cards.Count; i++)
        {
            if (GlobalInfo.cards[i] > 0)
            {
                if (GlobalInfo.cards[i] > 1)
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

    public void SetCardsBackPack()
    {
        foreach (Transform child in GameObject.Find("CardsBackPack").transform)
        {
            Destroy(child.gameObject);
        }
        for (var i = 0; i < GlobalInfo.backPack.Count; i++)
        {
            if (GlobalInfo.backPack[i] > 0)
            {
                GameObject cO = Instantiate(cardsBackPack[GlobalInfo.backPack[i]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsBackPack").transform);
                cO.transform.localPosition = cardsBackPack[i].transform.position;
                cO.transform.localScale = new Vector3(1, 1, 1);
                cO.GetComponent<Image>().sprite = spritesCards[GlobalInfo.backPack[i] - 1];
                cO.transform.GetChild(0).gameObject.SetActive(true);
                cO.transform.GetChild(1).gameObject.SetActive(true);
                cO.transform.GetComponent<CardButtonRemove>().position = i;
            }
            else
            {
                GameObject cO = Instantiate(cardsBackPack[GlobalInfo.backPack[i]]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsBackPack").transform);
                cO.transform.localPosition = cardsBackPack[i].transform.position;
                cO.transform.localScale = new Vector3(1, 1, 1); 
                cO.GetComponent<Image>().sprite = spritesCards[5];
                cO.transform.GetChild(0).gameObject.SetActive(false);
                cO.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void AddCardToBackPack(int card)
    {
        for (var i = 0; i < GlobalInfo.backPack.Count; i++)
        {
            if (GlobalInfo.backPack[i] == 0)
            {
                GlobalInfo.backPack[i] = card;
                GlobalInfo.cards[card - 1] = GlobalInfo.cards[card - 1] - 1;
                SetCardsBackPack();
                return;
            }
        }
    }

    public void RemoveCardToBackPack(int card, int position)
    {
        GlobalInfo.backPack[position] = 0;
        GlobalInfo.cards[card] = GlobalInfo.cards[card] + 1;
        SetCardsBackPack();
    }
}
