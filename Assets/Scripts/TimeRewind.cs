using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeRewind : MonoBehaviour
{

    public bool isRewinding = false;
    public float recordTime = 20f;
    
    List<PointInTime> pointsInTime;

    Rigidbody2D rb;

    private int rewindCount;
    private int rewindCounter = 0;
    private bool loop;
    private float prevY;
    private float currentY;


    // Start is called before the first frame update
    void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire3") && GetComponent<PlayerMovement>().enabled == false)
        {
            StartRewind();
        }
        if (Input.GetButtonDown("Fire3") && GetComponent<PlayerMovement>().enabled == true)
        {
            StopRewind();
        }*/
    }

    void FixedUpdate()
    {
        prevY = currentY;
        currentY = rb.position.y;
        if (isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Record()
    {
        //Float are seconds that get recorded
        if (pointsInTime.Count > Mathf.Round(recordTime/ Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    //void Rewind()
    //{
    //    if (pointsInTime.Count > 0)
    //    {
    //        PointInTime pointInTime = pointsInTime[0];
    //        transform.position = pointInTime.position;
    //        transform.rotation = pointInTime.rotation;
    //        pointsInTime.RemoveAt(0);
    //    }
    //    else
    //    {
    //        StopRewind();
    //    }


    //}

    void Rewind()
    {
        if (rewindCounter < rewindCount && loop == true)
        {
            PointInTime pointInTime = pointsInTime[rewindCounter];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            rewindCounter++;
            if (rewindCounter == rewindCount)
            {
                loop = false;
                rewindCounter--;
                //Debug.Log("Rewind finished");
            }
        }
        else
        {
            //Debug.Log("Start replay " + rewindCounter);
            rewindCounter--;
            PointInTime pointInTime = pointsInTime[rewindCounter];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            if (rewindCounter == 0)
            {
                loop = true;
            }
        }

    }


    public void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
        rewindCount = pointsInTime.Count;
        //Debug.Log(rewindCount);
        //rewindCounter = rewindCount;
        loop = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        //rb.isKinematic = false;
    }
}
