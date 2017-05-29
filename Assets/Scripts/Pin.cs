using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreashold = 10f;
    public float distanceRaise = 70f;

    private Rigidbody rigibody;

    // Use this for initialization
    void Start () {
        rigibody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool isStanding()
    {
        Vector3 rotation = transform.rotation.eulerAngles;

        float rx = rotation.x;
        float rz = rotation.z;

        if(rx <= standingThreashold && rz <= standingThreashold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        if(isStanding())
        {
            rigibody.useGravity = false;
            transform.Translate(new Vector3(0f, distanceRaise, 0f), Space.World);
        }
    }

    public void Lower()
    {
        rigibody.useGravity = false;
        transform.Translate(new Vector3(0f, -distanceRaise, 0f), Space.World);
    }
}
