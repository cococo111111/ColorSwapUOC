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
    public TextMeshPro barText;
    bool finished = false;
    SpriteRenderer colorGoal;
    public Sprite empty;

    private void Start()
    {
        colorGoal = this.GetComponent<SpriteRenderer>();
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
                    colorGoal.sprite = empty;
                    colorGoal.GetComponent<Transform>().localScale = new Vector2(0.53f, 0.53f);
                    colorGoal.transform.position = new Vector3(colorGoal.transform.position.x, colorGoal.transform.position.y - 0.01f, colorGoal.transform.position.z);
                    finished = true;
                    GlobalInfo.numberGrids--;                    
                }
            }
        }
    }
}
