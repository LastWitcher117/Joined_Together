using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRewind : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Player3" || collision.gameObject.tag == "Player4")
        {
            gameObject.transform.Rotate(0, 180, 0);
            this.gameObject.SetActive(false);

        }
    }
}
