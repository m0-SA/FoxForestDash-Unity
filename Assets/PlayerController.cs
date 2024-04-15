using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 4.0f,
        jumpForce = 7.5f,
        fallMultiplier = 5f,
        lowJumpMultiplier = 10f,
        doubleJumpPower = 12f,
        rollDashPower = 20f,
        dashingTime = 0.1f,
        dashingCD = 2f;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    Vector2 bottomOffset;

    [SerializeField]
    TrailRenderer trailRenderer;
    
    float collisionRadius = 0.2f;
    bool doubleJump;
    bool canRollDash = true;
    bool isRollDashing;

    


    Animator animator;
    SpriteRenderer renderer;
    Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        // keep a reference to this component for efficiency
        rigidbody = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // prevents player from doing anything while dashing
        if (isRollDashing)
        {
            return;
        }

        // left and right input
        float moveInput = Input.GetAxis("Horizontal");


        var isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,
                collisionRadius,
                groundLayer);
        // apply a horizontal velocity by multiplying input by our speed constant
        // keep the vertical (Y) velocity the same for now
        rigidbody.velocity = new Vector2(moveInput * speed, rigidbody.velocity.y);

        if (isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }


        //has the player pressed jump?
        if (Input.GetButtonDown("Jump"))
        {
            // test whether what is at our feet is part of the "ground" layer
            if (isGrounded || doubleJump)
            {
                // trigger the jump animation
                animator.SetTrigger("jump");
                // apply our jump force to the Y axis
                // keep the horizontal velocity the same as before
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, doubleJump ? doubleJumpPower : jumpForce);

                doubleJump = !doubleJump;
                
            }
        }

        // checks if grounded to be used in fall animation transitions.
        if (isGrounded)
        {
            animator.SetBool("grounded", true);
        }
        else
        {
            animator.SetBool("grounded", false);
        }

        // pass the horizonal and vertical velocity to the animator
        animator.SetFloat("y", rigidbody.velocity.y);
        animator.SetFloat("x", moveInput);

        // face the appropriate direction
        if (moveInput < 0)
            renderer.flipX = true;
        else if (moveInput > 0)
            renderer.flipX = false;


        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier
                * Time.deltaTime;
        }
        else if (rigidbody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y *
                lowJumpMultiplier * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.E) && canRollDash)
        {
            StartCoroutine(RollingDash());
        }


    }
    private void FixedUpdate()
    {
        if (isRollDashing)
        {
            return;
        }
        /*
       // left and right input
       float moveInput = Input.GetAxis("Horizontal");



       // apply a horizontal velocity by multiplying input by our speed constant
       // keep the vertical (Y) velocity the same for now


       float targetSpeed = moveInput * speed;
       float speedDif = targetSpeed - rigidbody.velocity.x;
       float accelRate = (Mathf.Abs(targetSpeed) > velocityPower) ? acceleration : decceleration;
       float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, 0.9f) * Mathf.Sign(speedDif);

       rigidbody.AddForce(movement * Vector2.right);


       // pass the horizonal and vertical velocity to the animator
       animator.SetFloat("y", rigidbody.velocity.y);
       animator.SetFloat("x", moveInput);

       // face the appropriate direction
       if (moveInput < 0)
           renderer.flipX = true;
       else if (moveInput > 0)
           renderer.flipX = false;*/
    

}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }

    private IEnumerator RollingDash()
    {
        canRollDash = false;
        isRollDashing = true;
        float ogGravity = rigidbody.gravityScale;
        rigidbody.gravityScale = 0f;
        rigidbody.velocity = new Vector2(rigidbody.velocity.x * rollDashPower, 0f);
        trailRenderer.emitting = true;
        animator.SetTrigger("rolling");
        yield return new WaitForSeconds(dashingTime);
        trailRenderer.emitting = false;
        rigidbody.gravityScale = ogGravity;
        isRollDashing = false;
        yield return new WaitForSeconds(dashingCD);
        canRollDash = true;
    }
}


