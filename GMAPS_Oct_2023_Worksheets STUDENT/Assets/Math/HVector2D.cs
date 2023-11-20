using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//[Serializable]
public class HVector2D
{
    public float x, y;
    public float h;

    public HVector2D(float _x, float _y)
    {
        x = _x;
        y = _y;
        h = 1.0f;
    }

    public HVector2D(Vector2 _vec)
    {
        x = _vec.x;
        y = _vec.y;
        h = 1.0f;
    }

    public HVector2D()
    {
        x = 0;
        y = 0;
        h = 1.0f;
    }

    public static HVector2D operator +(HVector2D vector1 , HVector2D vector2 )
    {
       return new HVector2D(vector1.x + vector2.x, vector1.y + vector2.y);
    }

    public static HVector2D operator -(HVector2D vector1, HVector2D vector2)
    {
        return new HVector2D(vector1.x - vector2.x, vector1.y - vector2.y);
    }

    public static HVector2D operator *(HVector2D vector, float scalar)
    {
        return new HVector2D(vector.x * scalar, vector.y * scalar);
    }

    public static HVector2D operator /(HVector2D vector, float divisor)
    {
        if (divisor != 0)
        {
            return new HVector2D(vector.x / divisor, vector.y / divisor);
        }
        else
        {
            Debug.LogError("Division by zero!");
            return vector; 
        }
    }

    public float Magnitude()
    {
        return Mathf.Sqrt(x * x + y * y);
    }

    public void Normalize()
    {
        float mag = Magnitude();
        if (mag != 0)
        {
            x /= mag;
            y /= mag;
        }
    }

    public float DotProduct(HVector2D vector)
    {
        return x * vector.x + y * vector.y;
    }

    public HVector2D Projection(HVector2D ontoVector)
    {
        float dotProduct = DotProduct(ontoVector);
        float ontoVectorMagSquared = ontoVector.x * ontoVector.x + ontoVector.y * ontoVector.y;
        HVector2D projection = ontoVector * (dotProduct / ontoVectorMagSquared);
        return projection;
    }

    public float FindAngle(HVector2D vector)
    {
        float dotProduct = DotProduct(vector);
        float magProduct = Magnitude() * vector.Magnitude();
        float cosTheta = dotProduct / magProduct;
        float angleInRadians = Mathf.Acos(cosTheta);
        return angleInRadians * Mathf.Rad2Deg; // Convert radians to degrees
    }


    public Vector2 ToUnityVector2()
    {
        return new Vector2(x, y);
    }

    public Vector3 ToUnityVector3()
    {
        return new Vector3(x, y, h);
    }

     public void Print()
    {
        Debug.Log($"Vector: ({x}, {y}, {h})");
    }
}
