using UnityEngine;
using System.Collections;

public class TestRots : MonoBehaviour {
    float angle;
    public float yRot;
    Vector3 axis;
    public Vector3 newUp = Vector3.up;
    // Use this for initialization
    void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (newUp.magnitude != 0)
                newUp.Normalize();
            //Quaternion q = Quaternion.AngleAxis(90f, transform.rotation * Vector3.left);
            //Debug.Log(transform.rotation);
            //transform.rotation *= q;
            //Debug.Log(transform.rotation);
            //Debug.Log("q: " + q);
            transform.rotation = RotateWithUp(newUp, yRot);
        }
        transform.rotation.ToAngleAxis(out angle, out axis);
    }

    public static Quaternion RotateWithUp(Vector3 up, float yRot)
    {
        float xyAngle = Mathf.Atan2(up.x, up.y) * Mathf.Rad2Deg;
        float zyAngle = Mathf.Atan2(up.z, up.y) * Mathf.Rad2Deg;

        Quaternion firstRotation = Quaternion.AngleAxis(xyAngle, Vector3.back);
        Quaternion secondRotation = Quaternion.AngleAxis(zyAngle, Vector3.right);
        Quaternion thirdRotation = Quaternion.Euler(0f, yRot, 0f);

        Quaternion q = Quaternion.identity;
        q *= firstRotation;
        q *= secondRotation;
        q *= thirdRotation;
        return q;
    }

    void OnDrawGizmos()
    {
        //Vector3 v = transform.rotation * Vector3.up;
        //Debug.Log(v);
        //DrawArrow.ForGizmo(transform.position, axis * 10, Color.magenta);
        //DrawArrow.ForGizmo(transform.position, transform.rotation * Vector3.left * 5, Color.green);
        //DrawArrow.ForGizmo(transform.position, v * 5, Color.blue);
        DrawArrow.ForGizmo(transform.position, newUp * 5, Color.blue);
        

        

    }
}
