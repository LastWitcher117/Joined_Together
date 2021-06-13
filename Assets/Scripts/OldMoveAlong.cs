using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldMoveAlong : MonoBehaviour
{
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" && this.gameObject.GetComponent<OldPlayerMovement>().enabled == false)
        {
            collision.collider.transform.SetParent(transform);
        }
        if (collision.gameObject.tag == "Player2" && this.gameObject.GetComponent<OldPlayerMovement>().enabled == false)
        {
            collision.collider.transform.SetParent(transform);
        }
        if (collision.gameObject.tag == "Player3" && this.gameObject.GetComponent<OldPlayerMovement>().enabled == false)
        {
            collision.collider.transform.SetParent(transform);
        }
        if (collision.gameObject.tag == "Player4" && this.gameObject.GetComponent<OldPlayerMovement>().enabled == false)
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
