using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TunnelManager : MonoBehaviour {
    public GameObject player;
    public float gravityMultiplier = 10f;
    void Start () {
        //var mesh = GetComponent<MeshFilter>().sharedMesh;
        //middles = new Vector3[mesh.triangles.Length / 6];
        //normals = new Vector3[mesh.triangles.Length / 6];
        //int counter = 0;
        //for (int i = 0; i < mesh.triangles.Length / 3; i++)
        //{
        //    int index = i * 3;
        //    Vector3 p1 = mesh.vertices[mesh.triangles[index]];
        //    Vector3 p2 = mesh.vertices[mesh.triangles[index + 1]];
        //    Vector3 p3 = mesh.vertices[mesh.triangles[index + 2]];
        //    Vector3 middle = (p1 + p2 + p3) / 3f;
        //    middles[counter] = middle;
        //    normals[counter] = mesh.normals[mesh.triangles[index]];
        //    counter++;
        //    if ((i - 1) % 4 == 0)
        //    {
        //        i+=2;
        //        continue;
        //    }
        //}
    }
    Vector3[] middles, normals;
    void Update () {
        //var mesh = GetComponent<MeshFilter>().sharedMesh;
        //float closest = float.MaxValue;
        //Vector3 closestNormal = Vector3.up;
        //Vector3 closestMiddle = Vector3.zero;
        //for (int i = 0; i < middles.Length; i++)
        //{
        //    float dist = (player.transform.position - middles[i]).sqrMagnitude;
        //    if (dist < closest)
        //    {
        //        closest = dist;
        //        closestMiddle = middles[i];
        //        closestNormal = normals[i];
        //    }
        //}
        //Physics.gravity = closestNormal * gravityMultiplier;
    }
    void OnDrawGizmos()
    {
        //DrawArrow.ForGizmo(player.transform.position, Physics.gravity, Color.red);
        //if (middles != null)
        //{
        //    for (int i = 0; i < middles.Length; i++)
        //    {
        //        DrawArrow.ForGizmo(middles[i], normals[i], Color.green);
        //    }
        //}
    }

}
