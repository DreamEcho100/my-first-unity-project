using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 500f;

    private bool isGrounded = true;

    private float movementX;
    private float movementY;

    private Rigidbody2D myBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private readonly string WALK_ANIMATION = "Walk";
    private readonly string GROUND_TAG = "Ground";
    private readonly string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveKeyboard();
        HandleJump();
        Animate();
    }

    //private void FixedUpdate()
    //{
    //HandleJump();
    //}

    void MoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void Animate()
    {
        // Moving right
        if (movementX > 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = false;
        }
        // Moving left
        else if (movementX < 0)
        {
            animator.SetBool(WALK_ANIMATION, true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="collision">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG) && !isGrounded) isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG)) Destroy(gameObject);
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="collision">The collision Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)) Destroy(gameObject);

    }
}

