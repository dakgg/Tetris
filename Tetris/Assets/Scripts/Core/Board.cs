using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Transform EmptySprite;
    public int Height = 30;
    public int Width = 10;

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

    void DrawEmptyCells()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                var go = Instantiate(EmptySprite, new Vector3(x, y, 0), Quaternion.identity) as Transform;
                go.name = $"Board({x},{y})";
                go.transform.parent = transform;
            }
        }
    }
}