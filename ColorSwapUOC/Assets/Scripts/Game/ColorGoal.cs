using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorGoal : MonoBehaviour
{
    public int color;
    public int quantity;
    public GameObject bar;
    public GameObject check;
    public TextMeshPro barText;
    bool finished = false;

    private void Start()
    {
        check.SetActive(false);
    }

    private void Update()
    {
        if (quantity == 1)
        {
            bar.SetActive(false);
        }
        else
        {
            barText.text = "x" + quantity.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!finished)
        {
            int colorOther = other.GetComponent<Cell>().color;
            if (colorOther == color)
            {
                quantity--;
                //Agafem la posicio per pasarla al sistemes de particles de la puntuació al gameManager
                other.GetComponent<Cell>().positionGoal = this.gameObject.transform.position;
                other.GetComponent<Cell>().onGoal = true;
                GameObject.Find("UIController").GetComponent<PlayEffects>().DragDropGoalSound();
                if (quantity == 0)
                {
                    check.SetActive(true);
                    finished = true;
                    GlobalInfo.numberGrids--;                    
                }
            }
        }
    }
}
