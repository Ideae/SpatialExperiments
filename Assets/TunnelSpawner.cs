using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TunnelSpawner : MonoBehaviour {
    List<GameObject> tunnels;
	// Use this for initialization
	void Start () {
        SpawnTunnels();
    }
    void SpawnTunnels()
    {
        tunnels = new List<GameObject>();
        int amount = Random.Range(1, 2);
        for (int i = 0; i < amount; i++)
        {
            GameObject tun = new GameObject("Tunnel" + i);
            tun.transform.parent = transform.parent;
            tun.AddComponent<TunnelGenerator>();
            tunnels.Add(tun);

        }
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1))
        {
            foreach(GameObject t in tunnels)
            {
                Destroy(t);
            }
            SpawnTunnels();

            var player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = new Vector3(0, 5, 0);
                player.transform.rotation = Quaternion.identity;
                Physics.gravity = Vector3.down;
            }
        }
	}
}
