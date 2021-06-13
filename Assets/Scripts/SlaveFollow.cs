using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveFollow : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D rb;
    
    public float moveSpeed;
    public float jumpForce = 5;
    private Vector2 movement = new Vector2(1,1);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 3)
        {
            Walk();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(movement * jumpForce);
        }
    }

    private void Walk()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
