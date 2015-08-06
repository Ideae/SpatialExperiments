using UnityEngine;
using System.Collections;

public class Ethan : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    float makeitavariable = 25f;
    // Update is called once per frame
    void Update () {
        if (transform.position.y < -makeitavariable) Application.LoadLevel(Application.loadedLevel);

	}
}
