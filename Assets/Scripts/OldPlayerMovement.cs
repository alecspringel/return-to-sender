using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerMovement : MonoBehaviour
{
    public float accel = 1.0f;
    public float runMult = 1.25f;
    public float jumpHeight = 1.0f;
    public float maxWalkSpeed = 1.0f;

    private Animator animator;
    private Vector3 movement;
    private Rigidbody rigid;
    private bool jump = false;
    private bool isGrounded = false;
    private bool run = false;
    private float maxRun;
    private float maxSpeed;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        maxRun = maxWalkSpeed * runMult;  // Calculate the max run speed
    }

    void Update()
    {
        updateMovement();  // Get player input
        if (movement != Vector3.zero)
        {
            // Look in the direction of movement
            rigid.rotation = Quaternion.LookRotation(-movement);
        }
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

        if (run)
        {
            maxSpeed = maxRun;  // Changes max speed if running
        }
        else
        {
            maxSpeed = maxWalkSpeed;  // Changes back to default
        }

        rigid.AddForce(movement * accel);  // Move character


        // This is the behavior that controls top speed
        if (rigid.velocity.magnitude > maxSpeed)
        {
            float currentJump = rigid.velocity.y;  // We don't want to clamp vertical
            Vector3 newSpeed = rigid.velocity.normalized * maxSpeed;
            newSpeed.y = currentJump;
            rigid.velocity = newSpeed;
        }
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

        if (Input.GetButton("Run"))
        {
            run = true;
        }
        else
        {
            run = false;
        };

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

    // Checks if player is grounded for jumping
    void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }

    void OnCollisionEnter(Collision other)
    {
        // Stops player from jumping forever
        rigid.velocity = new Vector3(rigid.velocity.x, 0.0f, rigid.velocity.z);
    }
}
