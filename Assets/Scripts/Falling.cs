using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    Rigidbody2D rb;

    public float waitTime = 1f;

    private ContactPoint2D[] hitObject;
    private Vector2 hit;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Invoke("Drop", waitTime);
        }
        else
        {
            rb.isKinematic = true;
        }*/


        hitObject = collision.contacts;
        hit = hitObject[0].normal;
        //Debug.LogWarning(hitObject);
        //collision.collider.transform.SetParent(transform);
        //Debug.LogWarning(collision.contacts[0]);
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {


            if (Vector2.Dot(hit, Vector2.up) > 0)
            { // top
              // Back
              //Debug.LogWarning("bot hit");
                return;
            }
            else if (Vector2.Dot(hit, Vector2.down) < 0)
            {
                // Front
                //Debug.LogWarning("front hit");
                return;
            }
            else if (Vector2.Dot(hit, Vector2.right) == 0)
            {
                // Sides
                Vector2 spawnPosition = transform.position;
                Invoke("Drop", waitTime);
            }

            else
            {
                rb.isKinematic = true;
            }
        }
    }

    void Drop()
    {
        rb.isKinematic = false;
    }

}
