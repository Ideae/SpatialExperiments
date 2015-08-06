using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class TunnelGenerator : ProcBase {
    //void Start() {
    //
    //}
    
	// Update is called once per frame
	void Update () {
        
	}

    public override Mesh BuildMesh()
    {
        MeshBuilder builder = new MeshBuilder();
        float length = 1f;
        float width = 10f;
        float height = 1f;

        Vector3 currentPos = Vector3.zero;
        Vector3 forward = Vector3.forward * length;
        Vector3 right = Vector3.right * width;
        Vector3 up = Vector3.up * height;
        Vector3 tempForward = forward;
        //Vector3 tempRight = right;
        int amount = 200;
        //int periodUp = 40;
        //int periodRight = 20;
        int periodUp = Random.Range(10,80);
        int periodRight = Random.Range(10, 80);
        float ampUp = Random.Range(0.1f, 5f);
        float ampRight = Random.Range(0.1f, 0.2f);

        

        for (int i = 0; i < amount; i++)
        {
            BuildQuadDouble(builder, currentPos, tempForward, right);
            currentPos += tempForward;

            float sinefactUp = Mathf.Sin(((float)i / periodUp) * Mathf.PI * 2f) - 0.5f;
            float sinefactRight = Mathf.Sin(((float)i / periodRight) * Mathf.PI * 2f) - 0.5f;
            tempForward = forward + up * sinefactUp * ampUp + right * sinefactRight * ampRight;
            //float r = 1f;
            //float randUp = Random.Range(-r, r);
            //float randRight = Random.Range(-r, r);
            //tempForward = forward + up * randUp + right * randRight;
        }
        return builder.CreateMesh();
    }

    /*
    //manually creating triangle
    void Start() {
        Mesh mesh = new Mesh();
        var mf = gameObject.AddComponent<MeshFilter>();
        mf.mesh = mesh;

        Vector3[] verts = new Vector3[] {
            new Vector3(-1f, -1f, -1f),
            new Vector3(1f, -1f, -1f),
            new Vector3(0f, -1f, 1f),
            new Vector3(0f, 1f, 0f)
        };
        int[] triangles = new int[] {
            0,1,2,
            0,3,1,
            0,2,3,
            1,3,2
        };
        
        //Vector3[] normals = new Vector3[verts.Length];
        //for(int i = 0; i < triangles.Length / 3; i++)
        //{
        //    int index = i * 3;
        //    Vector3 ba = verts[triangles[index + 1]] - verts[triangles[index]];
        //    Vector3 ca = verts[triangles[index + 2]] - verts[triangles[index]];
        //    Vector3 cross = Vector3.Cross(ba, ca);
        //    for(int j = index; j < index + 3; j++)
        //    {
        //        normals[triangles[j]] += cross;
        //    }
        //}
        //for (int i = 0; i < normals.Length; i++)
        //{
        //    normals[i].Normalize(); 
        //}
        
        mesh.vertices = verts;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        

        MeshRenderer mr = gameObject.AddComponent<MeshRenderer>();
        mr.material.shader = Shader.Find("Standard");
    }
	*/
}
