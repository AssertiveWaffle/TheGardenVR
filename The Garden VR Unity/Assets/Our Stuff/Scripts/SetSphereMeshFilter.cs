using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSphereMeshFilter : MonoBehaviour
{

    void Start()
    {
        // Get the mesh filter component
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        if (meshFilter != null)
        {
            // Set the mesh filter's mesh to a sphere mesh
            meshFilter.mesh = CreateSphereMesh();
        }
        else
        {
            Debug.LogWarning("SetSphereMeshFilter: MeshFilter not found!");
        }
    }

    Mesh CreateSphereMesh()
    {
        // Create a new sphere mesh
        Mesh mesh = new Mesh();

        // Set the mesh vertices to a sphere
        mesh.vertices = new Vector3[] {
            new Vector3(0, 0.5f, 0), // Top vertex
            new Vector3(0.5f, 0, 0), // Right vertex
            new Vector3(0, 0, -0.5f), // Back vertex
            new Vector3(-0.5f, 0, 0), // Left vertex
            new Vector3(0, -0.5f, 0), // Bottom vertex
            new Vector3(0, 0, 0.5f) // Front vertex
        };

        // Set the mesh triangles to form a sphere
        //mesh.triangles = new int[] {
         //   0, 1, 5, // Top triangle
           // 1, 2, 5, // Right triangle
            //2, 3, 5, // Back triangle
            //3, 4, 5, // Left triangle
            //4, 0, 5 // Bottom triangle
        //};

        // Recalculate the mesh's normals and bounds
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }

}