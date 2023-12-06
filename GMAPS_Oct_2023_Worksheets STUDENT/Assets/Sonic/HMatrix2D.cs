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

    // Note that the second argument is a HVector2D object
    //
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
      (
        left.entries[0, 0] * right.x + left.entries[0, 1] * right.y,
        left.entries[1, 0] * right.x + left.entries[1, 1] * right.y
      );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
     (
         // Row 1
         left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],
         left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],
         left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

         // Row 2
         left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],
         left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],
         left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

         // Row 3
         left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],
         left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],
         left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]
     );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        if (left is null || right is null) // Check if one of the matrices is null.
            return false;

        // Assuming elements is a 2D array containing matrix elements.
        // Check if matrices have the same dimensions.
        if (left.entries.GetLength(0) != right.entries.GetLength(0) ||
            left.entries.GetLength(1) != right.entries.GetLength(1))
            return false;

        // Compare corresponding elements in the matrices.
        for (int i = 0; i < left.entries.GetLength(0); i++)
        {
            for (int j = 0; j < left.entries.GetLength(1); j++)
            {
                if (left.entries[i, j] != right.entries[i, j])
                {
                    return false; // If any pair of elements doesn't match, matrices are not equal.
                }
            }
        }

        return true; // Matrices are equal if all elements match.
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        // Utilize the previously defined equality operator to implement the inequality operator.
        return !(left == right);
    }

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

    public void SetTranslationMat(float transX, float transY)
    {
        // First, set the matrix to an identity matrix
        SetIdentity();

        // Apply translation values to the matrix
        entries[0, 2] = transX;
        entries[1, 2] = transY;
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();

        // Convert degrees to radians
        float rad = rotDeg * Mathf.Deg2Rad;

        float cosValue = Mathf.Cos(rad);
        float sinValue = Mathf.Sin(rad);

        entries[0, 0] = cosValue;
        entries[0, 1] = -sinValue;
        entries[1, 0] = sinValue;
        entries[1, 1] = cosValue;
    }

    //    public void SetScalingMat(float scaleX, float scaleY)
    //    {
    //        // your code here
    //    }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        HMatrix2D otherMatrix = (HMatrix2D)obj;

        // Check if matrices have the same dimensions.
        if (entries.GetLength(0) != otherMatrix.entries.GetLength(0) ||
            entries.GetLength(1) != otherMatrix.entries.GetLength(1))
        {
            return false;
        }

        // Compare corresponding elements in the matrices.
        for (int i = 0; i < entries.GetLength(0); i++)
        {
            for (int j = 0; j < entries.GetLength(1); j++)
            {
                if (entries[i, j] != otherMatrix.entries[i, j])
                {
                    return false; // If any pair of elements doesn't match, matrices are not equal.
                }
            }
        }

        return true; // Matrices are equal if all elements match.
    }

    public override int GetHashCode()
    {
        unchecked // Overflow is fine for this purpose
        {
            int hash = 17;
            // Adjust hash code based on matrix elements
            for (int i = 0; i < entries.GetLength(0); i++)
            {
                for (int j = 0; j < entries.GetLength(1); j++)
                {
                    hash = hash * 23 + entries[i, j].GetHashCode();
                }
            }
            return hash;
        }
    }

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