﻿using System.Collections;
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
        TakeTheCards();
    }

    void TakeTheCards()
    {
        //Comprobem les cartas que hi han a la motxila
        if (CheckCardsBackPack())
        {
            for (var i = 0; i < GlobalInfo.backPack.Count; i++)
            {
                position.Add (GlobalInfo.backPack[i]);
            }
            //position = GlobalInfo.backPack;
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

    public void ActionCard(string card, int position)
    {
        if (card == "coinsCard(Clone)")
        {
            GameManager.Instance.ParticleCardsPoints(5, 1000);
            GlobalInfo.backPack[position] = GlobalInfo.backPack[position] - 1;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "x2Card(Clone)")
        {
            GlobalInfo.score = GlobalInfo.score * 2;
            GlobalInfo.backPack[position] = GlobalInfo.backPack[position] - 1;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "oneMinCard(Clone)")
        {
            GameManager.timer = GameManager.timer + 60;
            GlobalInfo.backPack[position] = GlobalInfo.backPack[position] - 1;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "eraserCard(Clone)")
        {
            GameManager.Instance.ClearGrid();
            GlobalInfo.backPack[position] = GlobalInfo.backPack[position] - 1;
            LoadConfig.Instance.SaveDataGame();
        }
        if (card == "level1Card(Clone)")
        {
            GlobalInfo.speed = 2;
            GlobalInfo.backPack[position] = GlobalInfo.backPack[position] - 1;
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
}
