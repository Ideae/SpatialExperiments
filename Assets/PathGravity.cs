using UnityEngine;
using System.Collections;

public class PathGravity : MonoBehaviour {
    public bool ApplyGravity = true;
    public float gravityMultiplier = 10f;
    void Start () {
        var cc = GetComponent<CharacterController>();
        
    }
	void Update () {
	
	}
    //void OnCollisionEnter(Collision collision)
    //{
    //    Physics.gravity = -collision.contacts[0].normal * gravityMultiplier;
    //}
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (ApplyGravity)
        {
            Physics.gravity = -hit.normal * gravityMultiplier;
        }
    }
    void OnDrawGizmos()
    {
        DrawArrow.ForGizmo(transform.position, Physics.gravity, Color.red);
    }
}
