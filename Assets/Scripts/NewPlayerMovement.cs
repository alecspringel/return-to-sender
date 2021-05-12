using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewPlayerMovement : MonoBehaviour
{
    public float jumpHeight = 1.0f;
    public float maxSpeed = 1.0f;

    private Animator animator;
    private Vector3 movement;
    private Rigidbody rigid;
    private Collider coll;
    private bool jump = false;
    private bool isGrounded = false;
    private float speedToAdd = 0.0f;
    private float groundDistance;

    public Text timeText;
    private float startTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        groundDistance = coll.bounds.extents.y;

        startTime = Time.time;
    }

    void Update()
    {
        updateMovement();  // Get player input
        if (movement != Vector3.zero)
        {
            // Look in the direction of movement
            rigid.rotation = Quaternion.LookRotation(-movement);
        }

        isGrounded = checkGrounded();

        float t = (3*60) - Time.time;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timeText.text = minutes + ":" + seconds;
    }
    void FixedUpdate()
    {
        if (jump)
        {
            if (isGrounded)  // Jump if button pressed and grounded
            {
                rigid.AddForce(new Vector3(0.0f, jumpHeight, 0.0f));
            }
            jump = false;
        }
        Vector3 horizontalSpeed = new Vector3(rigid.velocity.x, 0.0f, rigid.velocity.z);
        speedToAdd = maxSpeed - horizontalSpeed.magnitude;
        rigid.AddForce(movement * speedToAdd);  // Move character
    }

    void updateMovement()
    {
        float movementHori = 0;
        float movementVert = 0;


        movementHori = Input.GetAxis("Horizontal");

        movementVert = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (movementHori != 0 || movementVert != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        movement = new Vector3(-movementVert, 0.0f, movementHori);
    }

    bool checkGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.up, groundDistance + 0.1f);
    }

    void OnCollisionEnter(Collision other)
    {
        // Stops player from jumping forever
        rigid.velocity = new Vector3(rigid.velocity.x, 0.0f, rigid.velocity.z);
    }
}