using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();

    void Start()
    {
        mat.SetIdentity();
        mat.Print();

        Question2();
    }

    private void Question2()
    {
        // Declare three HMatrix2D objects: mat1, mat2, and resultMat
        HMatrix2D mat1 = new HMatrix2D(new float[,]
        {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
        });

        HMatrix2D mat2 = new HMatrix2D(new float[,]
        {
        { 9, 8, 7 },
        { 6, 5, 4 },
        { 3, 2, 1 }
        });

        HMatrix2D resultMat;

        // Declare one HVector2D object: vec1
        HVector2D vec1 = new HVector2D(2, 3); 

        // Perform matrix operations
        resultMat = mat1 * mat2;

        // Perform matrix-vector multiplication
        HVector2D resultVector = mat1 * vec1;

        // Print or use the results for testing
        Debug.Log("Resultant Matrix:");
        resultMat.Print();

        Debug.Log("Resultant Vector:");
        resultVector.Print();
    }
}