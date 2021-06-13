using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveFollow : MonoBehaviour
{
    private Transform player;
    
    public float moveSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 3)
        {
            Walk();
        }
    }

    private void Walk()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
