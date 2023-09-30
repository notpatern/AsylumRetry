using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [Header("ref")]
    Rigidbody rb;
    public Transform orientation;
    public PlayerInputs playerControls;
    public LayerMask isGround;
    public float playerHeight;
    public float playerSlideHeight;
    public float currentPlayerHeight;
    public Transform Player;
    public GameObject playerGame;

    [Header("Values")]
    public float moveSpeed;
    public float jumpStrength;
    public float maxMoveSpeed;
    public float maxAirMoveSpeed;
    public float maxSlideSpeed;
    float currentMaxSpeed;
    public float airMultiplierValue;
    public float groundDrag;
    public float airDrag;
    public float slideDrag;
    public float slideSpeed;
    float currentDrag;
    public float dashStrength;
    public float dashDrag;
    public float dashDuration;
    public float stamina;
    public float slamSpeed;
    public float slamDrag;
    float currentStam;
    bool dashing;
    bool grounded;
    bool sliding;
    bool jumping;
    bool slamming;
    float slamMultiplier;
    float groundTime;
    bool slamPressed;
    Vector3 slideDirection;


    Vector3 moveDirection;
    private float airMultiplier;
    private InputAction move;
    private InputAction vertical;
    private InputAction dash;
    private InputAction sgp;

    private void Awake()
    {
        playerControls = new PlayerInputs();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        vertical = playerControls.Player.Vertical;
        vertical.Enable();

        dash = playerControls.Player.Dash;
        dash.Enable();
        dash.performed += Dash;

        sgp = playerControls.Player.SGP;
        sgp.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        vertical.Disable();
        dash.Disable();
        sgp.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = groundDrag;
        currentPlayerHeight = 1;
        Player.localScale = new Vector3(Player.localScale.x, playerHeight, Player.localScale.z);
        grounded = false;
        dashing = false;
        sliding = false;
        slamming = false;
        slamPressed = false;
        slamMultiplier = 1;
        groundTime = 0;
    }

    void Update()
    {
        CheckGrounded();
        StateMachine();
        DashDuration();
        PlayerSizeManager();
        SlamMultiplierMachine();
    }

    private void FixedUpdate()
    {
        MoveInputs();
        Sgp();
    }

    private void SlamMultiplierMachine()
    {
        if (slamming)
        {
            slamMultiplier += Time.deltaTime * 3.5f;
        }
        if (!slamming && slamMultiplier > 1f)
        {
            slamMultiplier -= Time.deltaTime;
        }
        if (slamMultiplier < 1f) slamMultiplier = 1f;
        if (grounded && slamMultiplier > 1f)
        {
            groundTime += Time.deltaTime;
            if (groundTime > 0.25f)
                slamMultiplier = 1f;
        }
        else
        { groundTime = 0f; }
        if (grounded && slamMultiplier == 1f)
            groundTime = 0f;
    }

    private void StateMachine()
    {
        if (grounded && !dashing)
        {
            rb.drag = groundDrag;
            airMultiplier = 1f;
            currentMaxSpeed = maxMoveSpeed;
            rb.useGravity = true;
        }
        if ((dashing) || (grounded && dashing))
        {
            rb.drag = dashDrag;
            currentMaxSpeed = 0f;
            rb.useGravity = false;
        }
        if (sliding)
        {
            SlideMovement();
            airMultiplier = 0.1f;
            rb.drag = slideDrag;
        }
        if (!dashing && !grounded)
        {
            rb.drag = airDrag;
            airMultiplier = airMultiplierValue;
            currentMaxSpeed = maxAirMoveSpeed;
            rb.useGravity = true;
        }
        if (slamming)
        {
            GroundPoundMovement();
        }
    }

    private void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, currentPlayerHeight + 0.2f, isGround);
        if (grounded) jumping = false;
    }

    private void Jump()
    {
        jumping = true;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * (jumpStrength * slamMultiplier), ForceMode.Impulse);
    }

    private void MoveInputs()
    {
        float x = move.ReadValue<Vector2>().x;
        float y = move.ReadValue<Vector2>().y;

        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        if (x > 0 && xMag > maxMoveSpeed) x = 0;
        if (x < 0 && xMag < -maxMoveSpeed) x = 0;
        if (y > 0 && yMag > maxMoveSpeed) y = 0;
        if (y < 0 && yMag < -maxMoveSpeed) y = 0;

        moveDirection = orientation.forward * y + orientation.right * x;
        rb.AddForce(moveDirection.normalized * 10f * moveSpeed * airMultiplier, ForceMode.Acceleration);

        if (vertical.ReadValue<float>() > 0 & grounded)
        {
            Jump();
        }
    }

    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }

    private void Dash(InputAction.CallbackContext context)
    {
        if (slamming) StopGroundPound();
        dashing = true;
        float x = move.ReadValue<Vector2>().x;
        float y = move.ReadValue<Vector2>().y;

        Vector3 dashDirection = new Vector3(0f, 0f, 0f);
        if (!sliding)
        {
            dashDirection = orientation.forward * y + orientation.right * x;
            if (x == 0f && y == 0f)
            {
                dashDirection = orientation.forward * 1 + orientation.right * x;
            }

            rb.velocity = new Vector3(0f, 0f, 0f);

            rb.AddForce(dashDirection * dashStrength, ForceMode.Impulse);
        }
    }

    private void DashDuration()
    {
        if (dashing && dashDuration > 0)
        {
            dashDuration -= Time.deltaTime;
        }
        if (vertical.ReadValue<float>() > 0 && grounded)
        {
            dashing = false;
            dashDuration = 0.2f;
        }
        if (dashing && dashDuration <= 0)
        {
            dashing = false;
            dashDuration = 0.2f;
        }
    }


    private void PlayerSizeManager()
    {
        if (!sliding)
        {
            currentPlayerHeight = playerHeight;
        }
        if (sliding)
        {
            currentPlayerHeight = playerSlideHeight;
        }

        Player.localScale = new Vector3(Player.localScale.x, currentPlayerHeight, Player.localScale.z);
    }

    private void Sgp()
    {
        if (grounded)
        {
            if (sgp.ReadValue<float>() > 0 && !sliding && !jumping && !slamPressed)
            {
                slamPressed = true;
                StartSlide();
            }
            if (sliding && vertical.ReadValue<float>() > 0) StopSlide();
        }

        if ((sgp.ReadValue<float>() == 0) && sliding)
        {
            StopSlide();
        }

        if (!grounded && !slamming && !sliding)
        {
            if (sgp.ReadValue<float>() > 0 && !slamPressed)
            {
                slamPressed = true;
                StartGroundPound();
            }
        }
        if (slamming && grounded)
        {
            StopGroundPound();
        }

        if (sgp.ReadValue<float>() == 0) slamPressed = false;
    }

    private void StartSlide()
    {
        float x = move.ReadValue<Vector2>().x;
        float y = move.ReadValue<Vector2>().y;

        sliding = true;
        Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.75f, Player.transform.position.z);

        slideDirection = orientation.forward * y + orientation.right * x;
        if (slideDirection.x == 0f && slideDirection.z == 0f) slideDirection = orientation.forward * 1 + orientation.right * x;
    }

    private void SlideMovement()
    {
        rb.velocity = new Vector3(slideDirection.x * slideSpeed, rb.velocity.y, slideDirection.z * slideSpeed);
    }

    private void StopSlide()
    {
        sliding = false;
        rb.drag = 0f;
    }

    private void StartGroundPound()
    {
        rb.drag = slamDrag;
        slamming = true;
    }

    private void GroundPoundMovement()
    {
        rb.velocity = new Vector3(0f, -slamSpeed, 0f);
    }

    private void StopGroundPound()
    {
        rb.drag = 0f;
        slamming = false;
    }
}
