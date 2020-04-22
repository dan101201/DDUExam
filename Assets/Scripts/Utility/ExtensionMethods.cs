using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static Vector2 Rotate(this Vector2 vector, float degrees) {
        float length = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
        float rotation = Mathf.Asin(vector.y/length)+degrees;
        float height = Mathf.Sin(rotation*length);
        return new Vector2(Mathf.Sqrt(length*length-height*height),height);
    }
}
