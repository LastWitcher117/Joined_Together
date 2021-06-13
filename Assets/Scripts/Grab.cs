using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        
        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }
    }
}
