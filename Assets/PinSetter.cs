using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public Text standingPinDisp;
    public float settledTime = 3f;
    public GameObject pinSet;

    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int currentStandingCount;
    private bool isBallEntered = false;
    private Ball ball;

    // Use this for initialization
    void Start () {
        ball = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isBallEntered)
        {
            standingPinDisp.text = currentStandingCount.ToString();

            if (isSettled())
            {
                settledState();
                Debug.Log("Settled");
            }
        }
    }

    void settledState()
    {
        standingPinDisp.color = Color.green;
        isBallEntered = false;
        ball.Reset();
    }



    public void RaisePins()
    {
        Debug.Log("Raise");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lower");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void Renew()
    {
        Debug.Log("Renew");
        Instantiate(pinSet, new Vector3(0f, 0f, 1829f),Quaternion.identity);
    }

    public bool isSettled()
    {
        currentStandingCount = CountStanding();

        if (currentStandingCount != lastStandingCount)
        {
            lastStandingCount = currentStandingCount;
            lastChangeTime = Time.time;
            return false;
        }
        else
        {
            Debug.Log("currentStandingCount " + currentStandingCount);
            if (Time.time - lastChangeTime > settledTime)
            {
                lastStandingCount = -1;
                return true;
            }
        }

        return false;
    }

    int CountStanding()
    {
        int standingCount = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                standingCount++;
            }
        }

        return standingCount;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.GetComponent<Ball>())
        {
            isBallEntered = true;
            standingPinDisp.color = Color.red;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (!collider.GetComponent<Ball>())
        {
            Destroy(collider.transform.parent.gameObject);
        }
        Debug.Log("ball exit");
    }
}
