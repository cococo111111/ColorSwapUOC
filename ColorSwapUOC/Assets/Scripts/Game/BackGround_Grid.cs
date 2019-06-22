using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Grid : MonoBehaviour
{
    //Grid
    public int rows;
    public int cols;
    public Vector2 gridOffset;
    public GameObject cell;

    private BoxCollider2D gridSize;
    private Vector2 originalCellSize;

    private Vector2 cellScale;
    private Vector2 cellSize;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<RectTransform>().transform.position = new Vector3 (this.GetComponent<RectTransform>().transform.position.x, this.GetComponent<RectTransform>().transform.position.y, 1);     
        PaintCells();
    }

    public void Clean()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void PaintCells()
    {
        gridSize = GetComponent<BoxCollider2D>();
        originalCellSize = cell.GetComponent<SpriteRenderer>().sprite.bounds.size;

        cellSize = new Vector2(gridSize.size.x / (float)cols, gridSize.size.y / (float)rows);

        cellScale.x = cellSize.x / (originalCellSize.x + gridOffset.x);
        cellScale.y = cellSize.y / (originalCellSize.y + gridOffset.y);

        cell.transform.localScale = new Vector2(cellScale.x, cellScale.y);

        offset.x = gridSize.offset.x - ((gridSize.size.x) / 2) + cellSize.x / 2;
        offset.y = gridSize.offset.y - ((gridSize.size.y) / 2) + cellSize.y / 2;

        int sufixName = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                sufixName++;
                //add the cell size so that no two cells will have the same x and y position
                Vector2 pos = new Vector2(col * cellSize.x + transform.position.x + offset.x, row * cellSize.y + transform.position.y + offset.y);

                //instantiate the game object, at position pos, with rotation set to identity
                GameObject cO = Instantiate(cell, pos, Quaternion.identity) as GameObject;
                cO.GetComponent<SpriteRenderer>().sortingOrder = 0;
                cO.transform.position = new Vector3(cO.transform.position.x, cO.transform.position.y, 1);
                //set the parent of the cell to GRID so you can move the cells together with the grid;
                cO.transform.parent = transform;
            }
        }
    }
}
