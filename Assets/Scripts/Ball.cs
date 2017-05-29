using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Rigidbody rigibody;
    private AudioSource audioSource;
    private bool isInPlay = false;

    public bool testMode = true;
    public CameraController cameraController;
    public Vector3 lunchVolocity;


	// Use this for initialization
	void Start () {
        rigibody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigibody.useGravity = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(this.gameObject.transform.position.z <= 1529f)
        {
            cameraController.followObject(this.gameObject);
        }
    }

    public void lunchBall(Vector3 v)
    {
        this.isInPlay = true;
        this.rigibody.useGravity = true;
        this.rigibody.velocity = v;
        this.audioSource.Play();
    }

    public bool getIsInPlay()
    {
        return this.isInPlay;
    }

    public void setIsInPlay(bool isInplay)
    {
        this.isInPlay = isInplay;
    }

    public void Reset()
    {
        Debug.Log("Reset called");
        isInPlay = false;
        transform.position = new Vector3(0f, 20f, 50f);
        rigibody.velocity = new Vector3(0f, 0f, 0f);
        rigibody.angularVelocity = Vector3.zero;
        rigibody.useGravity = false;
    }
}
