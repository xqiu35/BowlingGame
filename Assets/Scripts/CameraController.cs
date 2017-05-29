using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Camera camera;
    public float x_offset;
    public float y_offset;
    public float z_offset;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    public void followObject(GameObject obj)
    {
        camera.transform.position = new Vector3(obj.transform.position.x+x_offset,
                                                obj.transform.position.y+y_offset,
                                                obj.transform.position.z+z_offset);
    }
}
