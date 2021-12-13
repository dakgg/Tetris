using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board GameBoard;
    public Spawner Spawner;
    
    Shape m_ActivieShape;
    float m_DropInterval = 0.5f;
    float m_TimeToDrop;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.transform.position = Vectorf.Round(Spawner.transform.position);
        m_ActivieShape = Spawner.SpawnShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBoard is null || Spawner is null) return;
        if (Time.time > m_TimeToDrop)
        {
            m_TimeToDrop = Time.time + m_DropInterval;
            if (m_ActivieShape != null)
            {
                m_ActivieShape.MoveDown();

                if (!GameBoard.IsValidPosition(m_ActivieShape))
                {
                    m_ActivieShape.MoveUp();
                    GameBoard.StoreShapeInGrid(m_ActivieShape);
                    m_ActivieShape = Spawner.SpawnShape();
                }
            }
        }
    }
}
