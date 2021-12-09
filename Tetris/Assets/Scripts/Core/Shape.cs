using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public bool m_CanRotate;

    void Start()
    {
        InvokeRepeating("MoveDown", 0, 0.5f);
    }

    void Move(Vector3 moveDir)
        => transform.position += moveDir;

    public void MoveLeft()
       => Move(Vector3.left);
    
    public void MoveRight()
        => Move(Vector3.right);

    public void MoveDown()
        => Move(Vector3.down);

    public void MoveUp()
        => Move(Vector3.up);

    public void RotateRight()
    {
        if (m_CanRotate) transform.Rotate(0, 0, -90);
    }

    public void RotateLeft()
    {
        if (m_CanRotate) transform.Rotate(0, 0, 90);
    }

}
