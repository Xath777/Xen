using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    private bool isFacingRight = true;
    private bool doubleJump = true;
    private bool canDash = true;
    private bool isDashing;
    private bool isLeft;
    private bool isRight;
    private float dashingPower = 14f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.2f;
    private Rigidbody2D rb;
    public Ghost ghost;
    public Vector2 movement;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (isDashing)
        {
            return;
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    private IEnumerator Dash()
    {
        ghost.makeGhost = true;
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(movement.x * dashingPower, movement.y * dashingPower);
        yield return new WaitForSeconds(dashingTime);
        ghost.makeGhost = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

        if(movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y); 
        }
        
    }

    public void OnDash()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
    }
}