using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public static DiamondManager Instance;
    public GameObject diamondGrid;
    public Sprite redDiamond;
    public Sprite greenDiamond;
    public Sprite yellowDiamond;
    public bool diamond = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("GenerateDiamonds", 1.0f, 1.0f);
    }

    void GenerateDiamonds()
    {
        Debug.Log(GameManager.diamond);
        diamondGrid.GetComponent<SpriteRenderer>().flipX = !diamondGrid.GetComponent<SpriteRenderer>().flipX;
        if (GetComponentInParent<Cell>().typeColor == 3 && !GameManager.diamond)
        {
            int appears = Random.Range(1, 40);
            if (appears == 1)
            {
                int typeDiamond = Random.Range(1, 10);
                if (typeDiamond == 1)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = yellowDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    GameManager.Instance.typeDiamond = "Yellow";
                    return;
                }
                if (typeDiamond == 2 || typeDiamond == 3 || typeDiamond == 4)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = redDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    GameManager.Instance.typeDiamond = "Red";
                    return;
                }
                if (typeDiamond != 1 && typeDiamond != 2 && typeDiamond != 3 && typeDiamond != 4)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = greenDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    GameManager.Instance.typeDiamond = "Green";
                    return;
                }
            }
        }
    }
    private void Update()
    {
        if (!diamond)
        {
            diamondGrid.GetComponent<SpriteRenderer>().sprite = null;
        }
    }





}
