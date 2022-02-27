using UnityEngine;
using UnityEngine.Events;

public class HeroController : MonoBehaviour
{
    public Animator animator;
    private Rigidbody2D rb;

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool facingRight = true;

    private bool isGrounded;
    public bool wasGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private void Awake()
    {
        GameStateManager.GetInstance.OnGameStateChanged += OnGameStateChanged;

    }

    private void OnDestroy()
    {
        GameStateManager.GetInstance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (!wasGrounded && isGrounded)
        {
            OnLanding();
        }

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
                animator.SetBool("IsJumping", true);
            }
            else
            {
                if (extraJumps > 0)
                {
                    rb.velocity = Vector2.up * (jumpForce / 2f);
                    extraJumps--;
                    animator.SetTrigger("DoubleJump");
                }
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
        Time.timeScale = newGameState == GameState.Gameplay ? 1f : 0f;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
