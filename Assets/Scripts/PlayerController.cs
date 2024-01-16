using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 7;
    [SerializeField]
    private float jumpHeight = 150;
    [SerializeField]
    private Transform groundChecker;
    [SerializeField]
    private LayerMask groundLayer;


    private Animator animator;
    private Rigidbody2D rigidbody2;
    private bool isFacingRight;
    private bool isGrounded;

    private void Start()
    {
        isFacingRight = true;
        rigidbody2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = false;
    }

    private void Update()
    {
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            isGrounded = false;
            animator.SetBool("isGrounded", false);
            rigidbody2.AddForce(new(x: 0, y: jumpHeight));
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));
        rigidbody2.velocity = new(x: move * maxSpeed, y: rigidbody2.velocity.y);
        if ((move > 0 && !isFacingRight) || (move < 0 && isFacingRight)) Flip();

        isGrounded = Physics2D.OverlapCircle(groundChecker.position, .15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("verticalSpeed", rigidbody2.velocity.y);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new(transform.localScale.x * -1, transform.localScale.y);
    }
}
