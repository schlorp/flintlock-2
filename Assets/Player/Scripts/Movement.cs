using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private GeneralInputActions inputactions;
    private InputAction move;
    private InputAction jump;

    private Rigidbody2D rb;
    [SerializeField] private Transform grouncheck;
    [SerializeField] private LayerMask groundlayer;
    [SerializeField] private float speed;
    [SerializeField] private float jumpheight;

    private bool hasjumped;
    private bool facingright = true;
    private float movedirectionx;

    private void Awake()
    {
        inputactions = new GeneralInputActions();
        rb = GetComponent<Rigidbody2D>();

        move = inputactions.Player.Move;
        jump = inputactions.Player.Jump;
    }
    private void OnEnable()
    {
        
        move.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    void Update()
    {
        Move();
        Jump();
        //CheckFlip();
    }

    void Move()
    {
        //get the value of the move binding
        movedirectionx = move.ReadValue<float>();
        //adding the value to the velocity
        rb.velocity = new Vector2(movedirectionx * speed, rb.velocity.y);
    }
    void Jump()
    {
        if(jump.IsPressed() && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpheight);
        }
    }
    /*
    private void CheckFlip()
    {
        if(movedirectionx == 1f && !facingright)
        {
            Flip();
        }
        if(movedirectionx == -1f && facingright)
        {
            Flip();
        }
    }
    private void Flip()
    {
        Vector3 currentscale = gameObject.transform.localScale;
        currentscale.x *= -1f;
        gameObject.transform.localScale = currentscale;

        facingright = !facingright;
    }
    */
    public bool GetFacingRight()
    {
        return facingright;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(grouncheck.position, 0.1f, groundlayer);
    }
}
