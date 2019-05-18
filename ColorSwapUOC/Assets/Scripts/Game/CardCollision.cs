using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardCollision : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 screenPoint;
    private Vector3 scanPos;
    private Vector3 initPosition;
    public bool onGrid;

    private void Start()
    {
        onGrid = false;
        initPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameObject.Find("Grid").GetComponent<BoxCollider2D>().enabled = true;
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = curPosition;
    }



    public void OnEndDrag(PointerEventData eventData)
    {
        if (onGrid)
        {
            CardsManager.Instance.ActionCard(this.name);
            this.gameObject.SetActive(false);
        }
        else
        {
            transform.position = initPosition;
        }

        GameObject.Find("Grid").GetComponent<BoxCollider2D>().enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Grid")
        {
            onGrid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Grid")
        {
            onGrid = false;
        }
    }
}