using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public string attackTrigger = "Attack";
    AudioSourceManager asm; 
    private Rigidbody2D rigidbody;
    private Animator animator;
    private bool isGrounded;
    [SerializeField]
    private Transform groundCheck;
    private SpriteRenderer spriteRenderer;
    public AudioClip KirbyFire; 
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        asm = GetComponent<AudioSourceManager>();
    }

    void Update()
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rigidbody.velocity.y);
        rigidbody.velocity = movement;
        // Flip sprite if moving left
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Jumping
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, LayerMask.GetMask("Ground"));
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // Attacking
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger(attackTrigger);
            asm.PlayOneShot(KirbyFire, false);
        }

        // Animation
        animator.SetFloat("Movement", Mathf.Abs(horizontalInput));
        animator.SetBool("IsGrounded", isGrounded);

    

 }