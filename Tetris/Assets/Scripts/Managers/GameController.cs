using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board GameBoard;
    public Spawner Spawner;
    
    Shape m_ActivieShape;
    float m_DropInterval = 0.1f;
    float m_TimeToDrop;
    float m_TimeToNextKey;

    [Range(0.02f, 1f)]
    float m_KeyRepeatRate = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.transform.position = Vectorf.Round(Spawner.transform.position);
        m_TimeToNextKey = Time.time;
        if (m_ActivieShape == null)
        {
            m_ActivieShape = Spawner.SpawnShape();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBoard == null || Spawner == null || m_ActivieShape != null) return;
        PlayerInput();
    }

    void PlayerInput()
    {   
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > m_TimeToNextKey || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.MoveRight();
            if (!GameBoard.IsValidPosition(m_ActivieShape)) m_ActivieShape.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Time.time > m_TimeToNextKey || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.MoveLeft();
            if (!GameBoard.IsValidPosition(m_ActivieShape)) m_ActivieShape.MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && Time.time > m_TimeToNextKey)
        {
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.RotateRight();
            if (!GameBoard.IsValidPosition(m_ActivieShape)) m_ActivieShape.RotateLeft();
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Time.time > m_TimeToNextKey || Time.time > m_TimeToDrop)
        {
            m_TimeToDrop = Time.time + m_DropInterval;
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.MoveDown();
            if (!GameBoard.IsValidPosition(m_ActivieShape))
            {
                m_TimeToNextKey = Time.time;
                m_ActivieShape.MoveUp();
                GameBoard.StoreShapeInGrid(m_ActivieShape);
                m_ActivieShape = Spawner.SpawnShape();
            }
        }
    }
}