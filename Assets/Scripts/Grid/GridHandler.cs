using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
	#region fields

	//caching
	[SerializeField] protected List<GridCell> _emptyCells;
	[SerializeField] protected List<GridCell> _fullCells;
	public List<GridCell> GetFullCells => _fullCells;
	public List<GridCell> GetEmptyCells => _emptyCells;

    public float CellSize;
    public GameObject GridCellPrefab;

    #endregion

    #region initialization

    public void SpawnGrid(int gridX, int gridY)
    {
        ClearExistingCells();

        Vector2 startingPoint = new Vector2((gridX * CellSize) / 2, (gridY * CellSize) / 2);

        for (int i = 0; i < gridY; i++)
        {
            for (int j = 0; j < gridX; j++)
            {

                GridCell cell = Instantiate(GridCellPrefab, transform).GetComponent<GridCell>();
                cell.SetHandler(this);

                cell.transform.localPosition = new Vector2(j * CellSize, i * CellSize) - startingPoint;
                _emptyCells.Add(cell);
            }
        }

        SetGridNeighbours(gridX, gridY);
    }

    private void ClearExistingCells()
	{
		_emptyCells = new List<GridCell>();
		_fullCells = new List<GridCell>();
	}

    private void SetGridNeighbours(int gridX, int gridY)
    {
        for (int i = 0; i < gridY; i++)
        {

            for (int j = 0; j < gridX; j++)
            {
                int rowStart = i * gridX;
                GridCell currentCell = _emptyCells[j + rowStart];
                if (j > 0)
                {
                    currentCell.SetNeighbor(_emptyCells[(j - 1) + rowStart], MoveDirection.Left);
                }
                if (j < gridX - 1)
                {
                    currentCell.SetNeighbor(_emptyCells[(j + 1) + rowStart], MoveDirection.Right);
                }
                if (i > 0)
                {
                    currentCell.SetNeighbor(_emptyCells[j + (rowStart - gridX)], MoveDirection.Down);
                }
                if (i < gridY - 1)
                {
                    currentCell.SetNeighbor(_emptyCells[j + (rowStart + gridX)], MoveDirection.Up);
                }
            }
        }
    }

	#endregion

	#region helpers

	public void AddMergeableItemToEmpty(MergableItem item)
	{
		var cell = _emptyCells.FirstOrDefault();
		if (cell != null)
		{
			item.AssignToCell(cell);
		}
	}

	public void ClearCell(GridCell cell)
	{
		if (_fullCells.Contains(cell))
		{
			_fullCells.Remove(cell);
			cell.ClearItem();
		}
		
		if (!_emptyCells.Contains(cell))
			_emptyCells.Add(cell);
	}


	public void SetCellState(GridCell cell, bool empty)
	{
		if (cell == null) return;
		if (empty)
		{
			if (_fullCells.Contains(cell))
			{
				_fullCells.Remove(cell);
			}

			if (_emptyCells.Contains(cell) == false)
			{
				_emptyCells.Add(cell);
			}
		}
		else
		{
			if (_emptyCells.Contains(cell))
			{
				_emptyCells.Remove(cell);
			}

			if (_fullCells.Contains(cell) == false)
			{
				_fullCells.Add(cell);
			}
		}
	}

	#endregion
}
