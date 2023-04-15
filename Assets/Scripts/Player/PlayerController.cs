using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    // movement variables
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = true;

    // Flag indicating whether the player is invincible
    public bool isInvincible = false;

    // reference to the animator component
    private Animator animator;

    // reference to the Rigidbody2D component
    private Rigidbody2D rb;

    // reference to the bark sound effect
    public AudioHandler audioHandler;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1); // Flip the sprite to face left

            // set running animation, but not if jumping
            if (!animator.GetBool("isJumping"))
            {
                animator.SetBool("IsRunning", true);
            }
        }

        // move right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1); // Flip the sprite to face right

            // set running animation, but not if jumping
            if (!animator.GetBool("isJumping"))
            {
                animator.SetBool("IsRunning", true);
            }
        }

        // stop moving
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            
            animator.SetBool("IsRunning", false);
        }

        // jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("isJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }

        // attack
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Bark();
            animator.SetBool("IsRunning", false); // stop the running animation
            animator.SetBool("isAttacking", true); // play the attack animation
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // function to handle the bark attack
    private void Bark()
    {
        audioHandler.PlayBarkSound(); // play the bark sound effect

        // check for enemies within a certain distance of the player
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                // get a reference to the enemy's health component
                EnemyHealth enemyHealth = collider.gameObject.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    // decrease the enemy's health
                    enemyHealth.TakeDamage(20);
                }
            }
            else if (collider.gameObject.CompareTag("Boss"))
            {
                // get a reference to the boss's health component
                BossHealth bossHealth = collider.gameObject.GetComponent<BossHealth>();
                if (bossHealth != null)
                {
                    // decrease the boss's health
                    bossHealth.TakeDamage(20);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
            animator.SetBool("IsRunning", false);
            animator.SetBool("isJumping", true);
        }
    }
}