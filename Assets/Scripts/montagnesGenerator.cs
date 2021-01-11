using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(MeshFilter))]
public class montagnesGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public int xSize = 100;
    public int zSize = 100;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        CreateShape();
        UpdateMesh();
    }
    void CreateShape(){
        
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i=0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize ; x++)
            {
                //float pn1 = Mathf.PerlinNoise(x * .3f, z*.3f) * 5f;
                //float pn2 = Mathf.PerlinNoise(x * .3f, z*.3f) * 2f;
                //float y = pn1+pn2;
                
                float y = 0f;
                if(x<xSize/6||z<zSize/6||x>5*(xSize/6)||z>5*(zSize/6)){
                    y = Mathf.PerlinNoise(x * .1f, z*.1f) * 50f;
                }else{
                    y = -3f;
                }
                vertices[i]= new Vector3(x,y,z);
                i++;
            }
        }

        triangles = new int[xSize*zSize*6];
        int vert = 0;
        int tris =0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0 ] = vert + 0; 
                triangles[tris + 1 ] = vert + xSize + 1; 
                triangles[tris + 2 ] = vert + 1; 
                triangles[tris + 3 ] = vert + 1; 
                triangles[tris + 4 ] = vert + xSize + 1; 
                triangles[tris + 5 ] = vert + xSize + 2; 

                vert++;
                tris+=6;
            }
            vert++;
        }
        

    }
    void UpdateMesh(){
        mesh.Clear();
        mesh.vertices =vertices;
        mesh.triangles=triangles;
        mesh.RecalculateNormals();
       
    }
    // private void OnDrawGizmos() {
    //     if(vertices==null)
    //         return;
        
    //     for (int i = 0; i < vertices.Length; i++)
    //     {
    //         Gizmos.DrawSphere(vertices[i], .1f);
    //     }
    // }
}
