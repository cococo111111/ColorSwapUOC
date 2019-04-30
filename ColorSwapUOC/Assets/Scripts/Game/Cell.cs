using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GUIAnimator;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    public static Cell Instance;
    public int x;
    public int y;
    public bool isColored;
    public int color;
    public Text messages;
    private Vector3 screenPoint;
    private Vector3 scanPos;
    public Vector3 initPosition;
    public bool sameColor = false;
    public bool newColor = false;
    public int newColorNumber;
    public Sprite originalSprite;
    public Sprite newSprite;
    public GameObject otherGrid;
    public bool onGoal = false;
    public int value;
    public int typeColor;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (color == 20)
        {
            typeColor = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cell")
        {
            //Coloquem l'altre casella mig transparent
            other.GetComponentInChildren<SpriteRenderer>().color = new Color(other.GetComponentInChildren<SpriteRenderer>().color.r, other.GetComponentInChildren<SpriteRenderer>().color.g, other.GetComponentInChildren<SpriteRenderer>().color.b, 0.5f);
            //guardem el sprite original en una variable
            originalSprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;
            //Mirem si les caselles son del mateix color, si es que si, marquem la variable sameColor true 
            if (other.gameObject.GetComponentInChildren<SpriteRenderer>().sprite == this.gameObject.GetComponent<SpriteRenderer>().sprite)
            {
                sameColor = true;
            }
            int colorOther = other.gameObject.GetComponentInChildren<Cell>().color;
            int colorThis = this.gameObject.GetComponent<Cell>().color;
            if (colorThis == 0 && colorOther == 1 || colorThis == 1 && colorOther == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[5];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[5];
                this.gameObject.GetComponent<Cell>().newColorNumber = 5;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 1 && colorOther == 2 || colorThis == 2 && colorOther == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[4];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[4];
                this.gameObject.GetComponent<Cell>().newColorNumber = 4;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 0 && colorOther == 2 || colorThis == 2 && colorOther == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[3];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[3];
                this.gameObject.GetComponent<Cell>().newColorNumber = 3;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 2 && colorOther == 4 || colorThis == 4 && colorOther == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[9];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[9];
                this.gameObject.GetComponent<Cell>().newColorNumber = 9;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 4 && colorOther == 1 || colorThis == 1 && colorOther == 4)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[10];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[10];
                this.gameObject.GetComponent<Cell>().newColorNumber = 10;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 1 && colorOther == 5 || colorThis == 5 && colorOther == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[8];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[8];
                this.gameObject.GetComponent<Cell>().newColorNumber = 8;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 0 && colorOther == 5 || colorThis == 5 && colorOther == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[6];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[6];
                this.gameObject.GetComponent<Cell>().newColorNumber = 6;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 0 && colorOther == 3 || colorThis == 3 && colorOther == 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[11];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[11];
                this.gameObject.GetComponent<Cell>().newColorNumber = 11;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }
            if (colorThis == 3 && colorOther == 2 || colorThis == 2 && colorOther == 3)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.colors[7];
                this.gameObject.GetComponent<Cell>().newSprite = GameManager.Instance.colors[7];
                this.gameObject.GetComponent<Cell>().newColorNumber = 7;
                this.gameObject.GetComponent<Cell>().otherGrid = other.gameObject;
                this.gameObject.GetComponent<Cell>().newColor = true;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        sameColor = false;
        this.gameObject.GetComponent<Cell>().newColor = false;
            if (other.tag == "Cell")
            {
                other.GetComponentInChildren<SpriteRenderer>().color = new Color(other.GetComponentInChildren<SpriteRenderer>().color.r, other.GetComponentInChildren<SpriteRenderer>().color.g, other.GetComponentInChildren<SpriteRenderer>().color.b, 1f);
                if (color != 20)
                {   
                    if (originalSprite != null)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
                    }
                    otherGrid = null;
                    originalSprite = null;
                    newSprite = null;
                }
            }
        
    }

    public void ResetGrid()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = GameManager.Instance.cellEmpty;
        color = 20;
        transform.parent.position = initPosition;
        otherGrid = null;
        originalSprite = null;
        newSprite = null;
        isColored = false;
        onGoal = false;
        typeColor = 0;
    }
}
