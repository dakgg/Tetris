using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Board GameBoard;
    public Spawner Spawner;
    
    Shape m_ActivieShape;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.transform.position = Vectorf.Round(Spawner.transform.position);
        m_ActivieShape = Spawner.GetRandomShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBoard is null || Spawner is null) return;
        if (m_ActivieShape != null)
        {
            m_ActivieShape.MoveDown();
        }
    }
}
