using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
	public void DragStart()
    {
        if(!ball.getIsInPlay())
        {
            Debug.Log("Drag start");
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }

    }

    public void DragEnd()
    {
        if (!ball.getIsInPlay())
        {
            if(!ball.testMode)
            {
                Debug.Log("Drag end");
                dragEnd = Input.mousePosition;
                endTime = Time.time;

                float duration = endTime - startTime;

                float launchSpeedX = (dragEnd.x - dragStart.x) / duration;
                float launchSpeedZ = (dragEnd.y - dragStart.y) / duration;


                Vector3 v = new Vector3(launchSpeedX, -50, launchSpeedZ);
                ball.lunchBall(v);
            }
            else
            {
                Vector3 v = new Vector3(0, -50, 800);
                ball.lunchBall(v);
            }
        }
    }

    public void moveStart(float amout)
    {
        if(!ball.getIsInPlay())
        {
            ball.transform.position = new Vector3(ball.transform.position.x + amout,
                                              ball.transform.position.y,
                                              ball.transform.position.z);
        }
    }
}
