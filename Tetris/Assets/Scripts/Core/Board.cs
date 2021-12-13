using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform EmptySprite;
    public int Height = 30;
    public int Width = 10;
    public int Header = 10;
    Transform[,] m_Grid;

    void Awake()
    {
        m_Grid = new Transform[Width, Height];
    }

    // Start is called before the first frame update
    void Start()
    {
        DrawEmptyCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool IsWithBoard(int x, int y) => (x >= 0 && x < Width && y >= 0);
    
    public bool IsValidPosition(Shape shape)
    {
        foreach (Transform child in shape.transform)
        {
            var pos = Vectorf.Round(child.position);
            if (!IsWithBoard((int)pos.x, (int)pos.y)) return false;
        }
        return true;
    }

    bool IsOccupied(int x, int y)
    {
        return (m_Grid[x,y] != null && m_Grid)
    }

    void DrawEmptyCells()
    {
        for (int x = 0; x < Width - Header; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var go = Instantiate(EmptySprite, new Vector3(x, y, 0), Quaternion.identity) as Transform;
                go.name = $"Board({x},{y})";
                go.transform.parent = transform;
            }
        }
    }

    public void StoreShapeInGrid(Shape shape) 
    {
        if (shape == null) return;
        foreach (Transform child in shape.transform)
        {
            var pos = Vectorf.Round(child.position);
            m_Grid[(int)pos.x, (int)pos.y] = child;
        }
    }   
}