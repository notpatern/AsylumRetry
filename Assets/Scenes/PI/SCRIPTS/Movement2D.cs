using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{ 
    Rigidbody rb;
    
    private float horizontalInput;
    private bool grounded;
    
    public LayerMask isGround;
    public float moveSpeed;
    public float maxSpeed;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        grounded = false;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        CheckGrounded();
        SpeedControl();

    }

    private void Update()
    {
        MyInput();
        StateMachine();


    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, 2f, isGround);
    }

    private void StateMachine()
    {
        if (grounded)
        {
            rb.drag = 5f;
            airMultiplier = 1f;
        }
        if (!grounded)
        {
            rb.drag = 0f;
            airMultiplier = 0.7f;
        }
    }
    private void SpeedControl()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatvel.magnitude > maxSpeed)
        {
            Vector3 limitedvel = flatvel.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedvel.x, rb.velocity.y, limitedvel.z);
        }
    }
    private void Move()
    {
            rb.AddForce(Vector3.right * moveSpeed * airMultiplier * horizontalInput, ForceMode.Impulse);
    }
}
