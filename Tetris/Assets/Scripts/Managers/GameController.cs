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
        m_ActivieShape = Spawner.SpawnShape();
        m_TimeToNextKey = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
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

    void PlayerInput()
    {
        // if (Input.GetButton("MoveRight") && Time.time > m_TimeToNextKey || Input.GetButtonDown("MoveRight"))
        if (Input.GetKey(KeyCode.RightArrow) && Time.time > m_TimeToNextKey || Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.MoveRight();
            if (!GameBoard.IsValidPosition(m_ActivieShape)) m_ActivieShape.MoveLeft();
        }

        if (Input.GetButton("MoveLeft") && Time.time > m_TimeToNextKey || Input.GetButtonDown("MoveLeft"))
        {
            m_TimeToNextKey = Time.time + m_KeyRepeatRate;
            m_ActivieShape.MoveLeft();
            if (!GameBoard.IsValidPosition(m_ActivieShape)) m_ActivieShape.MoveRight();
        }
    }
}
