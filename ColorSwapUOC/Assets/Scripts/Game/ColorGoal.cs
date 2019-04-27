﻿using System.Collections;
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!finished)
        {
            int colorOther = other.GetComponent<Cell>().color;
            if (colorOther == color)
            {
                quantity--;
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