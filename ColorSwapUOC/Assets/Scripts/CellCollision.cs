using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellCollision : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 screenPoint;
    private Vector3 scanPos;
    private Vector3 initPosition;

    private void Start()
    {
        initPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        if (this.GetComponentInChildren<Cell>().isColored)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
            transform.position = curPosition;
            this.GetComponentInChildren<SpriteRenderer>().color = new Color(this.GetComponentInChildren<SpriteRenderer>().color.r, this.GetComponentInChildren<SpriteRenderer>().color.g, this.GetComponentInChildren<SpriteRenderer>().color.b, 0.5f);
            this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 1;
        }
        if (this.GetComponentInChildren<Cell>().onGoal)
        {
            GlobalInfo.score += 95;
            this.GetComponentInChildren<Cell>().ResetGrid();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (this.GetComponentInChildren<Cell>().sameColor)
        {
            transform.position = initPosition;
            GameManager.Instance.ResetGrid(this.name);
            this.GetComponentInChildren<Cell>().originalSprite = null;
            this.GetComponentInChildren<Cell>().sameColor = false;
            GameObject.Find("UIController").GetComponent<PlayEffects>().DragDropSound();
            GlobalInfo.score = GlobalInfo.score + 5;
        }
        else
        {
            transform.position = initPosition;
        }

        if (this.GetComponentInChildren<Cell>().newColor)
        {

            GameManager.Instance.ChangeColor(this.GetComponentInChildren<Cell>().otherGrid.name, this.GetComponentInChildren<Cell>().newSprite, this.GetComponentInChildren<Cell>().newColorNumber);
            transform.position = initPosition;
            GameManager.Instance.ResetGrid(this.name);
            this.GetComponentInChildren<Cell>().otherGrid = null;
            this.GetComponentInChildren<Cell>().originalSprite = null;
            this.GetComponentInChildren<Cell>().newSprite = null;
            GameObject.Find("UIController").GetComponent<PlayEffects>().DragDropSound();
            GlobalInfo.score = GlobalInfo.score + 10;
        }
        else
        {
            transform.position = initPosition;
        }
        this.GetComponentInChildren<SpriteRenderer>().color = new Color(this.GetComponentInChildren<SpriteRenderer>().color.r, this.GetComponentInChildren<SpriteRenderer>().color.g, this.GetComponentInChildren<SpriteRenderer>().color.b, 1f);
        this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
    }

}
