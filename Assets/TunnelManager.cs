using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class TunnelManager : MonoBehaviour {
    Vector3[] middles, normals;

    // Use this for initialization
    void Start () {
        //int amount = Random.Range(1, 20);
        //for (int i = 0; i < amount; i++)
        //{
        //    GameObject g = new GameObject("tunnel" + i);
        //    g.transform.SetParent(transform);
        //    g.AddComponent<TunnelGenerator>();
        //}

        tunnel = new GameObject("tunnel");
        tunnel.transform.SetParent(transform);
        //tunnel.AddComponent<TunnelGenerator>();
        var mesh = GetComponent<MeshFilter>().sharedMesh;
        middles = new Vector3[mesh.triangles.Length / 6];
        normals = new Vector3[mesh.triangles.Length / 6];
        int counter = 0;
        for (int i = 0; i < mesh.triangles.Length / 3; i++)
        {
            int index = i * 3;
            Vector3 p1 = mesh.vertices[mesh.triangles[index]];
            Vector3 p2 = mesh.vertices[mesh.triangles[index + 1]];
            Vector3 p3 = mesh.vertices[mesh.triangles[index + 2]];

            Vector3 middle = (p1 + p2 + p3) / 3f;
            middles[counter] = middle;
            normals[counter] = mesh.normals[mesh.triangles[index]];
            counter++;

            if ((i - 1) % 4 == 0)
            {
                i+=2;
                continue;
            }
            

        }


        for(int i = 0; i < normals.Length; i++)
        {
            Debug.Log(i + " : " + normals[i]);
        }
    }
    public GameObject player;
    GameObject tunnel;
    int updateInterval = 10, updateCounter = 0;
    public float gravityMultiplier = 10f;
	// Update is called once per frame
	void Update () {
        if (true)//(updateCounter++ % updateInterval == 0)
        {
            var mesh = GetComponent<MeshFilter>().sharedMesh;
            float closest = float.MaxValue;
            Vector3 closestNormal = Vector3.up;
            Vector3 closestMiddle = Vector3.zero;

            for (int i = 0; i < middles.Length; i++)
            {

                float dist = (player.transform.position - middles[i]).sqrMagnitude;
                if (dist < closest)
                {
                    closest = dist;
                    closestMiddle = middles[i];
                    closestNormal = normals[i];
                    //closestNormal = mesh.normals[mesh.triangles[i*3]];
                }
            }


            //Vector3 diff = (player.transform.position - closestMiddle).normalized;
            //float dot = Vector3.Dot(diff, closestNormal);
            //if (dot > 0)
            //{
            //    closestNormal = -closestNormal;
            //}
            //Debug.Log(closestNormal);
            Physics.gravity = closestNormal * gravityMultiplier;
            //Debug.Log(Physics.gravity);
            
            //float maxVel = 2f;
            //var rb = player.GetComponent<CharacterController>();
            //Debug.Log(rb.velocity.magnitude);
            //if (rb.velocity.magnitude > maxVel)
            //{
            //    rb.velocity = rb.velocity.normalized * maxVel;
            //}

            //var fwd = player.transform.rotation * Vector3.forward;
            //Quaternion q = Quaternion.LookRotation(closestNormal, fwd);

            
            //player.transform.eulerAngles = new Vector3(q.eulerAngles.x, player.transform.eulerAngles.y, q.eulerAngles.z);
            //Debug.Log(player.transform.eulerAngles);
        }
    }
    void OnDrawGizmos()
    {
        DrawArrow.ForGizmo(player.transform.position, Physics.gravity, Color.red);
        if (middles != null)
        {
            for (int i = 0; i < middles.Length; i++)
            {
                DrawArrow.ForGizmo(middles[i], normals[i], Color.green);
            }
        }
    }

}
