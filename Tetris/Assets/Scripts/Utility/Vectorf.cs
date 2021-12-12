using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vectorf
{
    public static Vector2 Round(Vector2 vec2)
        => new Vector2(Mathf.Round(vec2.x), Mathf.Round(vec2.y));

    public static Vector3 Round(Vector3 vec3)
        => new Vector3(Mathf.Round(vec3.x), Mathf.Round(vec3.y), Mathf.Round(vec3.z));
}
