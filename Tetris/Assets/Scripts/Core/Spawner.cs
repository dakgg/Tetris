using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Shape[] AllShapes;

    public Shape GetRandomShape() => AllShapes[Random.Range(0, AllShapes.Length)];
    
    public Shape SpawnShape()
        => Instantiate(GetRandomShape(), transform.position, Quaternion.identity) as Shape;
        
    // Start is called before the first frame update
    void Start()
    {
        Vector2 originVector = new Vector2(4.3f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
