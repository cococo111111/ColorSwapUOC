using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellCollision : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 screenPoint;
    private Vector3 scanPos;
    private Vector3 initPosition;
    public bool onGoal = false;
    public bool onDiamond = false;

    private void Start()
    {
        initPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.gameOver)
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
                onGoal = true;
                Vector3 otherPosition = this.GetComponentInChildren<Cell>().positionGoal;
                if (this.GetComponentInChildren<DiamondManager>().diamond)
                {
                    if (GameManager.Instance.typeDiamond == "Green")
                    {
                        GameManager.Instance.ParticleDiamondPoints(otherPosition, 3, 100, 0);
                        GameManager.Instance.ParticlePoints(otherPosition, 3, 100, true);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        this.GetComponentInChildren<Cell>().typeColor = 0;
                    }
                    if (GameManager.Instance.typeDiamond == "Red")
                    {
                        GameManager.Instance.ParticleDiamondPoints(otherPosition, 4, 300, 1);
                        GameManager.Instance.ParticlePoints(otherPosition, 3, 100, true);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        this.GetComponentInChildren<Cell>().typeColor = 0;
                    }
                    if (GameManager.Instance.typeDiamond == "Yellow")
                    {
                        //GameManager.Instance.ParticleDiamondPoints(otherPosition, 5, 1000, 2);
                        CardsManager.Instance.GenerateCardYellowDiamond(otherPosition);
                        GameManager.Instance.ParticlePoints(otherPosition, 3, 100, true);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        this.GetComponentInChildren<Cell>().typeColor = 0;
                    }
                    this.GetComponentInChildren<DiamondManager>().diamond = false;
                }
                else
                {
                    GameManager.Instance.ParticlePoints(otherPosition, 3, 100, false);
                }
                this.GetComponentInChildren<Cell>().ResetGrid();
                onGoal = false;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.gameOver)
        {
            if (this.GetComponentInChildren<Cell>().sameColor)
            {
                string theOther = this.GetComponentInChildren<Cell>().otherGrid.name;
                GameObject otherCell = GameObject.Find(theOther);
                Vector3 otherPosition = GameObject.Find(theOther).transform.position;
                transform.position = initPosition;
                GameManager.Instance.ResetGrid(this.name);
                this.GetComponentInChildren<Cell>().originalSprite = null;
                this.GetComponentInChildren<Cell>().sameColor = false;
                if (this.GetComponentInChildren<DiamondManager>().diamond || GameObject.Find(theOther).GetComponentInChildren<DiamondManager>().diamond)
                {
                    onGoal = false;
                    onDiamond = true;
                    if (GameManager.Instance.typeDiamond == "Green")
                    {
                        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_GREEN_DAY);
                        GameManager.Instance.ParticleDiamondPoints(otherPosition, 3, 100, 0);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        GameObject.Find(theOther).GetComponentInChildren<DiamondManager>().diamond = false;
                        GameManager.Instance.ResetGrid(theOther);
                        onDiamond = false;
                    }
                    if (GameManager.Instance.typeDiamond == "Red")
                    {
                        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_CCCP);
                        GameManager.Instance.ParticleDiamondPoints(otherPosition, 4, 300, 1);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        GameObject.Find(theOther).GetComponentInChildren<DiamondManager>().diamond = false;
                        GameManager.Instance.ResetGrid(theOther);
                        onDiamond = false;
                
                    }
                    if (GameManager.Instance.typeDiamond == "Yellow")
                    {
                        //GameManager.Instance.ParticleDiamondPoints(otherPosition, 5, 1000, 2);
                        CardsManager.Instance.GenerateCardYellowDiamond(otherPosition);
                        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_LOVE_YELLOW);
                        this.GetComponentInChildren<DiamondManager>().diamond = false;
                        GameObject.Find(theOther).GetComponentInChildren<DiamondManager>().diamond = false;
                        GameManager.Instance.ResetGrid(theOther);
                        onDiamond = false;
                    }
                    return;
                }

                if (!onGoal && !onDiamond && otherCell.GetComponentInChildren<Cell>().isColored)
                {
                    otherPosition = GameObject.Find(theOther).transform.position;
                    GameManager.Instance.ParticlePoints(otherPosition, 0, 5, false);
                }
            }
            else
            {
                //onGoal = false;
                transform.position = initPosition;
            }

            if (this.GetComponentInChildren<Cell>().newColor)
            {
                string theOther = this.GetComponentInChildren<Cell>().otherGrid.name;
                GameManager.Instance.ChangeColor(this.GetComponentInChildren<Cell>().otherGrid.name, this.GetComponentInChildren<Cell>().newSprite, this.GetComponentInChildren<Cell>().newColorNumber);
                GameManager.Instance.UpdateTypeColor(this.GetComponentInChildren<Cell>().otherGrid.name, this.name);
                transform.position = initPosition;
                GameManager.Instance.ResetGrid(this.name);
                this.GetComponentInChildren<Cell>().otherGrid = null;
                this.GetComponentInChildren<Cell>().originalSprite = null;
                this.GetComponentInChildren<Cell>().newSprite = null;
                GameObject.Find("UIController").GetComponent<PlayEffects>().DragDropSound();
            }
            else
            {
                transform.position = initPosition;
            }
            this.GetComponentInChildren<SpriteRenderer>().color = new Color(this.GetComponentInChildren<SpriteRenderer>().color.r, this.GetComponentInChildren<SpriteRenderer>().color.g, this.GetComponentInChildren<SpriteRenderer>().color.b, 1f);
            this.GetComponentInChildren<SpriteRenderer>().sortingOrder = 0;
        }
    }

}
