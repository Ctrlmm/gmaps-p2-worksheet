using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        // Initialize an identity matrix if no values are provided
        entries = new float[,]
        {
            { 1, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 1 }
        };
    }


    public HMatrix2D(float[,] multiarray)
    {
        // Ensure the provided multiarray is a 3x3 matrix
        if (multiarray.GetLength(0) == 3 && multiarray.GetLength(1) == 3)
        {
            entries = multiarray;
        }
        else
        {
            
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
                     float m10, float m11, float m12,
                     float m20, float m21, float m22)
    {
        // Initialize the matrix using the provided parameters
        entries = new float[3, 3];

        // Assign values to the matrix elements using the provided parameters
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;

        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;

        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result.entries[i, j] = left.entries[i, j] + right.entries[i, j];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result.entries[i, j] = left.entries[i, j] - right.entries[i, j];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result.entries[i, j] = left.entries[i, j] * scalar;
            }
        }
        return result;
    }

    //    // Note that the second argument is a HVector2D object
    //    //
    //    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    //    {
    //        return // your code here
    //    }

    //    // Note that the second argument is a HMatrix2D object
    //    //
    //    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    //    {
    //        return new HMatrix2D
    //        (
    //            /* 
    //                00 01 02    00 xx xx
    //                xx xx xx    10 xx xx
    //                xx xx xx    20 xx xx
    //                */
    //            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],

    //            /* 
    //                00 01 02    xx 01 xx
    //                xx xx xx    xx 11 xx
    //                xx xx xx    xx 21 xx
    //                */
    //            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],

    //        // and so on for another 7 entries
    //    );
    //    }

    //    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    //    {
    //        // your code here
    //    }

    //    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    //    {
    //        // your code here
    //    }

    //    public HMatrix2D transpose()
    //    {
    //        return // your code here
    //    }

    //    public float GetDeterminant()
    //    {
    //        return // your code here
    //    }

    public void SetIdentity()
    {
        //for (int y = 0; y < entries.GetLength(0); y++)
        //{
        //    for (int x = 0; x < entries.GetLength(1); x++)
        //    {
        //        if (x == y)
        //        {
        //            entries[y, x] = 1;
        //        }
        //        else
        //        {
        //            entries[y, x] = 0;
        //        }
        //    }
        //}
        for (int y = 0; y < entries.GetLength(0); y++)
        {
            for (int x = 0; x < entries.GetLength(1); x++)
            {
                entries[y, x] = x == y ? 1 : 0;
            }
        }

    }

    //    public void SetTranslationMat(float transX, float transY)
    //    {
    //        // your code here
    //    }

    //    public void SetRotationMat(float rotDeg)
    //    {
    //        // your code here
    //    }

    //    public void SetScalingMat(float scaleX, float scaleY)
    //    {
    //        // your code here
    //    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}