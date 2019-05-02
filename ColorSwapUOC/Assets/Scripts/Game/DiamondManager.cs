using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public GameObject diamondGrid;
    public Sprite redDiamond;
    public Sprite greenDiamond;
    public Sprite yellowDiamond;
    public bool diamond = false;



    private void Start()
    {
        InvokeRepeating("GenerateDiamonds", 1.0f, 1.0f);
    }

    void GenerateDiamonds()
    {
        diamondGrid.GetComponent<SpriteRenderer>().flipX = !diamondGrid.GetComponent<SpriteRenderer>().flipX;
        if (GetComponentInParent<Cell>().typeColor == 3 && !GameManager.diamond)
        {
            Debug.Log("Lanzamos dados para ver si hay diamante");
            int appears = Random.Range(1, 20);
            if (appears == 1)
            {
                Debug.Log("HAY DIAMANTE");
                int typeDiamond = Random.Range(1, 10);
                if (typeDiamond == 1)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = yellowDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    return;
                }
                if (typeDiamond == 2 || typeDiamond == 3 || typeDiamond == 4)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = redDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    return;
                }
                if (typeDiamond != 1 && typeDiamond != 2 && typeDiamond != 3 && typeDiamond != 4)
                {
                    diamondGrid.GetComponent<SpriteRenderer>().sprite = greenDiamond;
                    diamond = true;
                    GameManager.diamond = true;
                    return;
                }
            }
        }
    }





}
