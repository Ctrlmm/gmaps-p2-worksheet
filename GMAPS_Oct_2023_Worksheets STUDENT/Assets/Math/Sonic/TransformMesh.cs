using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);

        Translate(10f, 10f);
        Rotate(45f);

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
        rotateMatrix.SetRotationMat(angle); // Assuming you have a method to set rotation in HMatrix2D

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
