using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour
{
    public static CardsManager Instance;
    public static int numberCards;
    public List<GameObject> cards = new List<GameObject>();
    public int [] card = {0,0,0,0,0};
    public static List<int> position = new List<int>();
    int pos;



    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        position.Clear();
        TakeTheCards();
    }

    void TakeTheCards()
    {
        //Primer netegem la grid de cartes
        foreach (Transform child in GameObject.Find("CardsManager").transform)
        {
            Destroy(child.gameObject);
        }
        //Comprobem les cartas que hi han a la motxila
        if (CheckCardsBackPack())
        {
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                position.Add (GlobalInfo.backPack[i]);
            }

            if (CountCardsBackPack() == 1)
            {
                pos = 0;
                for (var i = 0; i < GlobalInfo.backPack.Count; i++)
                {
                    if (GlobalInfo.backPack[i] > 0)
                    {
                        card[pos] = GlobalInfo.backPack[i];
                        Debug.Log(pos);
                        Debug.Log(card[pos]);
                        pos++;
                    }

                }
                GameObject cO = Instantiate(cards[card[0]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsManager").transform);
                cO.transform.localPosition = new Vector3 (GlobalInfo.Cards1[0].x, GlobalInfo.Cards1[0].y, GlobalInfo.Cards1[0].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                cO.transform.GetComponent<CardCollision>().position = pos;
            }

            if (CountCardsBackPack() == 2)
            {
                pos = 0;
                for (var i = 0; i < GlobalInfo.backPack.Count; i++)
                {
                    if (GlobalInfo.backPack[i] > 0)
                    {
                        card[pos] = GlobalInfo.backPack[i];
                        Debug.Log(card[pos]);
                        pos++;
                    }

                }
                GameObject cO = Instantiate(cards[card[0]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsManager").transform);
                cO.transform.localPosition = new Vector3(GlobalInfo.Cards2[0].x, GlobalInfo.Cards2[0].y, GlobalInfo.Cards2[0].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                cO.transform.GetComponent<CardCollision>().position = pos;

                GameObject c1 = Instantiate(cards[card[1]-1]) as GameObject;
                c1.transform.SetParent(GameObject.Find("CardsManager").transform);
                c1.transform.localPosition = new Vector3(GlobalInfo.Cards2[1].x, GlobalInfo.Cards2[1].y, GlobalInfo.Cards2[1].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c1.transform.GetComponent<CardCollision>().position = pos;
            }

            if (CountCardsBackPack() == 3)
            {
                pos = 0;
                for (var i = 0; i < GlobalInfo.backPack.Count; i++)
                {
                    if (GlobalInfo.backPack[i] > 0)
                    {
                        card[pos] = GlobalInfo.backPack[i];
                        pos++;
                    }

                }
                GameObject cO = Instantiate(cards[card[0]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsManager").transform);
                cO.transform.localPosition = new Vector3(GlobalInfo.Cards3[0].x, GlobalInfo.Cards3[0].y, GlobalInfo.Cards3[0].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                cO.transform.GetComponent<CardCollision>().position = pos;

                GameObject c1 = Instantiate(cards[card[1]-1]) as GameObject;
                c1.transform.SetParent(GameObject.Find("CardsManager").transform);
                c1.transform.localPosition = new Vector3(GlobalInfo.Cards3[1].x, GlobalInfo.Cards3[1].y, GlobalInfo.Cards3[1].z);
                pos = 0;
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c1.transform.GetComponent<CardCollision>().position = pos;

                GameObject c2 = Instantiate(cards[card[2]-1]) as GameObject;
                c2.transform.SetParent(GameObject.Find("CardsManager").transform);
                c2.transform.localPosition = new Vector3(GlobalInfo.Cards3[2].x, GlobalInfo.Cards3[2].y, GlobalInfo.Cards3[2].z);
                pos = 0;
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c2.transform.GetComponent<CardCollision>().position = pos;
            }

            if (CountCardsBackPack() == 4)
            {
                pos = 0;
                for (var i = 0; i < GlobalInfo.backPack.Count; i++)
                {
                    if (GlobalInfo.backPack[i] > 0)
                    {
                        card[pos] = GlobalInfo.backPack[i];
                        Debug.Log(card[pos]);
                        pos++;
                    }

                }
                GameObject cO = Instantiate(cards[card[0]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsManager").transform);
                cO.transform.localPosition = new Vector3(GlobalInfo.Cards4[0].x, GlobalInfo.Cards4[0].y, GlobalInfo.Cards4[0].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                cO.transform.GetComponent<CardCollision>().position = pos;

                GameObject c1 = Instantiate(cards[card[1]-1]) as GameObject;
                c1.transform.SetParent(GameObject.Find("CardsManager").transform);
                c1.transform.localPosition = new Vector3(GlobalInfo.Cards4[1].x, GlobalInfo.Cards4[1].y, GlobalInfo.Cards4[1].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c1.transform.GetComponent<CardCollision>().position = pos;

                GameObject c2 = Instantiate(cards[card[2]-1]) as GameObject;
                c2.transform.SetParent(GameObject.Find("CardsManager").transform);
                c2.transform.localPosition = new Vector3(GlobalInfo.Cards4[2].x, GlobalInfo.Cards4[2].y, GlobalInfo.Cards4[2].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c2.transform.GetComponent<CardCollision>().position = pos;

                GameObject c3 = Instantiate(cards[card[3]-1]) as GameObject;
                c3.transform.SetParent(GameObject.Find("CardsManager").transform);
                c3.transform.localPosition = new Vector3(GlobalInfo.Cards4[3].x, GlobalInfo.Cards4[3].y, GlobalInfo.Cards4[3].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c3.transform.GetComponent<CardCollision>().position = pos;
            }

            if (CountCardsBackPack() == 5)
            {
                pos = 0;
                for (var i = 0; i < GlobalInfo.backPack.Count; i++)
                {
                    if (GlobalInfo.backPack[i] > 0)
                    {
                        card[pos] = GlobalInfo.backPack[i];
                        Debug.Log(card[pos]);
                        pos++;
                    }

                }
                GameObject cO = Instantiate(cards[card[0]-1]) as GameObject;
                cO.transform.SetParent(GameObject.Find("CardsManager").transform);
                cO.transform.localPosition = new Vector3(GlobalInfo.Cards5[0].x, GlobalInfo.Cards5[0].y, GlobalInfo.Cards5[0].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                cO.transform.GetComponent<CardCollision>().position = pos;

                GameObject c1 = Instantiate(cards[card[1]-1]) as GameObject;
                c1.transform.SetParent(GameObject.Find("CardsManager").transform);
                c1.transform.localPosition = new Vector3(GlobalInfo.Cards5[1].x, GlobalInfo.Cards5[1].y, GlobalInfo.Cards5[1].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c1.transform.GetComponent<CardCollision>().position = pos;

                GameObject c2 = Instantiate(cards[card[2]-1]) as GameObject;
                c2.transform.SetParent(GameObject.Find("CardsManager").transform);
                c2.transform.localPosition = new Vector3(GlobalInfo.Cards5[2].x, GlobalInfo.Cards5[2].y, GlobalInfo.Cards5[2].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c2.transform.GetComponent<CardCollision>().position = pos;

                GameObject c3 = Instantiate(cards[card[3]-1]) as GameObject;
                c3.transform.SetParent(GameObject.Find("CardsManager").transform);
                c3.transform.localPosition = new Vector3(GlobalInfo.Cards5[3].x, GlobalInfo.Cards5[3].y, GlobalInfo.Cards5[3].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c3.transform.GetComponent<CardCollision>().position = pos;

                GameObject c4 = Instantiate(cards[card[4]-1]) as GameObject;
                c4.transform.SetParent(GameObject.Find("CardsManager").transform);
                c4.transform.localPosition = new Vector3(GlobalInfo.Cards5[4].x, GlobalInfo.Cards5[4].y, GlobalInfo.Cards5[4].z);
                for (var i = 0; i < position.Count; i++)
                {
                    if (position[i] > 0)
                    {
                        pos = i;
                        position[i] = 0;
                        break;
                    }
                }
                c4.transform.GetComponent<CardCollision>().position = pos;
            }
        }
    }

    public void ActionCard(string card, int position, GameObject cardGameObject)
    {
        if (card == "coinsCard(Clone)")
        {
            Destroy(cardGameObject);
            GameManager.Instance.ParticleCardsPoints(5, 1000);
            GameManager.Instance.MoneySound();
            GlobalInfo.backPack[position] = 0;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "x2Card(Clone)")
        {
            Destroy(cardGameObject);
            GlobalInfo.score = GlobalInfo.score * 2;
            GameManager.Instance.ParticleCardsPoints(14, 0);
            GameManager.Instance.DoubleSound();
            GlobalInfo.backPack[position] = 0;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "oneMinCard(Clone)")
        {
            Destroy(cardGameObject);
            GameManager.timer = GameManager.timer + 60;
            GameManager.Instance.ParticleCardsPoints(12, 0);
            GameManager.Instance.TicTacSound();
            GlobalInfo.backPack[position] = 0;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "eraserCard(Clone)")
        {
            Destroy(cardGameObject);
            GameManager.Instance.ClearGrid();
            GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_CLEAR_COLORS);
            GameManager.Instance.ParticleCardsPoints(11, 0);
            GameManager.Instance.BroomSound();
            GlobalInfo.backPack[position] = 0;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "level1Card(Clone)")
        {
            Destroy(cardGameObject);
            GlobalInfo.speed = 2.0f;
            GameManager.Instance.ParticleCardsPoints(13, 0);
            GameManager.Instance.BrakingSound();
            GlobalInfo.backPack[position] = 0;
            LoadConfig.Instance.SaveDataGame();
        }
    }

    bool CheckCardsBackPack()
    {
        bool check = false;
        for (var i=0; i < GlobalInfo.backPack.Count; i++)
        {
            if (GlobalInfo.backPack[i] > 0)
            {
                check = true;
                break;
            }
        }
        return check;
    }

    int CountCardsBackPack()
    {
        int count = 0;
        for (var i = 0; i < GlobalInfo.backPack.Count; i++)
        {
            if (GlobalInfo.backPack[i] > 0)
            {
                count++;
            }
        }
        return count;
    }

    public void GenerateCardYellowDiamond(Vector3 otherPosition)
    {
        int typeCard = Random.Range(1, 100);
        if (typeCard <= 50)
        {
            //La carta es 1000 puntos
            bool done = false;
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                if (GlobalInfo.backPack[i] == 0)
                {
                    GlobalInfo.backPack[i] = 1;
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                var newCard = GlobalInfo.cards[0] + 1;
                GlobalInfo.cards[0] = newCard;
            }
            GameManager.Instance.ParticleDiamondPoints(otherPosition, 6, 0, 2);
        }
        if (typeCard >= 51 && typeCard <= 70)
        {
            //La carta es borrado grid
            bool done = false;
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                if (GlobalInfo.backPack[i] == 0)
                {
                    GlobalInfo.backPack[i] = 2;
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                var newCard = GlobalInfo.cards[1] + 1;
                GlobalInfo.cards[1] = newCard;
            }
            GameManager.Instance.ParticleDiamondPoints(otherPosition, 7, 0, 2);
        }
        if (typeCard >= 71 && typeCard <= 85)
        {
            //La carta es level 1
            bool done = false;
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                if (GlobalInfo.backPack[i] == 0)
                {
                    GlobalInfo.backPack[i] = 3;
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                var newCard = GlobalInfo.cards[2] + 1;
                GlobalInfo.cards[2] = newCard;
            }
            GameManager.Instance.ParticleDiamondPoints(otherPosition, 8, 0, 2);
        }
        if (typeCard >= 86 && typeCard <= 95)
        {
            //La carta es 1 min more
            bool done = false;
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                if (GlobalInfo.backPack[i] == 0)
                {
                    GlobalInfo.backPack[i] = 4;
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                var newCard = GlobalInfo.cards[3] + 1;
                GlobalInfo.cards[3] = newCard;
            }
            GameManager.Instance.ParticleDiamondPoints(otherPosition, 9, 0, 2);
        }
        if (typeCard >= 96 && typeCard <= 100)
        {
            //La carta es puntuacion X2
            bool done = false;
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                if (GlobalInfo.backPack[i] == 0)
                {
                    GlobalInfo.backPack[i] = 5;
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                var newCard = GlobalInfo.cards[4] + 1;
                GlobalInfo.cards[4] = newCard;
            }
            GameManager.Instance.ParticleDiamondPoints(otherPosition, 10, 0, 2);
        }
        GameManager.diamond = false;
        LoadConfig.Instance.SaveDataGame();
        TakeTheCards();
    }
}
