using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float sprintMult = 1.5f;
    public float jumpHeight = 1.0f;

    private float movementX;
    private float movementY;
    private Rigidbody rigid;
    private float jump = 0.0f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = -movementVector.y;
    }

    void OnJump()
    {
        jump = 1.0f * jumpHeight;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementY, jump, movementX);
        rigid.AddForce(movement * speed);
        jump = 0.0f;
    }
}
