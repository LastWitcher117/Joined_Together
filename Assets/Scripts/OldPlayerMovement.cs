using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldPlayerMovement : MonoBehaviour
{
    public OldCharacterController controller;

    public GameObject otherPlayer;

    public float runSpeed = 40f;

    public float waitTime = 1f;

    public float maxSpeed = 40f;


    bool jump;
    bool swap;

    float horizontalMove = 0f;
    Animator animator;

    Rigidbody2D rb;
    Rigidbody2D rbOther;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbOther = otherPlayer.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", horizontalMove);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }


        if (Input.GetButtonDown("Fire3"))
        {
            otherPlayer.SetActive(true);
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            rbOther.velocity = new Vector2(0, 0);
            rbOther.isKinematic = false;
            GetComponent<OldPlayerMovement>().enabled = false;
            StartCoroutine(GiveSomeTime());
            otherPlayer.GetComponent<OldPlayerMovement>().enabled = true;
            otherPlayer.GetComponent<TimeRewind>().StopRewind();

        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        if (rb.velocity.y > maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rewind")
        {
            otherPlayer.SetActive(true);
            rb.velocity = new Vector2(0, 0);
            rb.isKinematic = true;
            rbOther.velocity = new Vector2(0, 0);
            rbOther.isKinematic = false;
            GetComponent<OldPlayerMovement>().enabled = false;
            StartCoroutine(GiveSomeTime());
            otherPlayer.GetComponent<OldPlayerMovement>().enabled = true;
            otherPlayer.GetComponent<TimeRewind>().StopRewind();
            collision.gameObject.SetActive(false);
            //otherPlayer.GetComponent<PlayerMovement>().enabled = true;
            //otherPlayer.GetComponent<TimeRewind>().StopRewind();

        }


    }

    private IEnumerator GiveSomeTime()
    {
        yield return new WaitForSeconds(waitTime);
        GetComponent<TimeRewind>().StartRewind();
    }
}
