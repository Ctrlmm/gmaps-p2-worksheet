using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }//Defines a public property vertices that stores an array of Vector3 points
    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();
    //Initializes all of these above 
   
    private MeshManager meshManager;
    HVector2D pos = new HVector2D(); //Initializes (again !) an instance of HVector2D named pos
   
    void Start()//This method is called at the very start 
    {
        meshManager = GetComponent<MeshManager>();
        //Gets the MeshManager component attached to the same GameObject this script is attached to 
        //assigns to meshManager
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        //Sets pos to a new HVector2D instance with the X and Y value
        Translate(10f, 10f);//Calls Translate(), to apply a translation of 10 units , idk why no use
        Rotate(45f);//Calls a method Rotate(),rotate 45 degrees

    }


    void Translate(float x, float y)
    {
     

        toOriginMatrix.SetIdentity();
        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y);

        fromOriginMatrix.SetIdentity();
        fromOriginMatrix.SetTranslationMat(pos.x + x, pos.y + y);

        Transform();

        pos = fromOriginMatrix * toOriginMatrix * pos;

      
    }
    void Rotate(float angle)
    {
        rotateMatrix.SetIdentity();
        rotateMatrix.SetRotationMat(angle); 

        transformMatrix.SetIdentity();
        transformMatrix = fromOriginMatrix * rotateMatrix; // Applying rotation after translation

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);
            vert = fromOriginMatrix * vert;
            vert = rotateMatrix * vert; // Apply rotation
            vert = toOriginMatrix * vert;

            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        meshManager.clonedMesh.vertices = vertices; // Update mesh vertices after transformation
        meshManager.clonedMesh.RecalculateBounds(); // Recalculate mesh bounds after modification
    }
}
