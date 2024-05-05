using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }


    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
            //if not, set instance to this
            Instance = this;
        //If instance already exists and it's not this:
        else if (Instance != this)
            // Then destroy this. This enforces the singleton pattern,
            // meaning there can only ever be one instance of a ScoreManager.
            Destroy(gameObject);
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

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

    public TextMeshProUGUI dashText;

    
  

    float collisionRadius = 0.1f;

    // coyote time gives small window after leaving ground to jump
    
    float coyoteTimeCounter;

    // jump buffer allows queuing next jump before fully hitting ground
    public float jbTime = 0.3f;
    public float jbCounter;


    
    
    bool isRollDashing;
    

    public float knockbackMultiplier;
    public float knockbackCounter;
    public float coyoteTime = 0.3f;

    public bool doubleJump;
    public bool knockbackDirection;
    public bool canRollDash = false;
    public bool dashUnlocked = false;
    public bool doubleJumpUnlocked = false;




    Animator animator;
    SpriteRenderer sRenderer;
    Rigidbody2D r;



    // Start is called before the first frame update
    void Start()
    {
        // keep a reference to this component for efficiency
        r = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        sRenderer = GetComponent<SpriteRenderer>();

    
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

        // apply a horizontal velocity by multiplying input by our speed constant
        // keep the vertical (Y) velocity the same for now
        if (knockbackCounter <= 0)
        {
            r.velocity = new Vector2(moveInput * speed, r.velocity.y);
        }
        else
        {
            animator.SetTrigger("jump");
            // if collision from right, move to left and vice versa
            if (knockbackDirection)
            {
                r.velocity = new Vector2(-knockbackMultiplier, knockbackMultiplier);
            }
            if (!knockbackDirection)
            {
                r.velocity = new Vector2(knockbackMultiplier, knockbackMultiplier);
            }
            knockbackCounter -= Time.deltaTime;
        }

        /* checks if grounded to be used in fall animation transitions.
          have coyote time if grounded. else coyote time starts to count down. */
        if (isGrounded())
        {
            trailRenderer.emitting = false;
            animator.SetBool("grounded", true);
  ;
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            trailRenderer.emitting = true;
            animator.SetBool("grounded", false);
            coyoteTimeCounter -= Time.deltaTime;
        }


        // double jump becomes available once grounded and not jumping. 
        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jbCounter = jbTime;
        }
        else
        {
            jbCounter -= Time.deltaTime;
        }

        // does the player have a jump buffer?
        if (jbCounter > 0f)
        {

            // test whether we have coyote time or we have double jump available
            if (coyoteTimeCounter > 0f || (doubleJump && doubleJumpUnlocked))
            {
                // trigger the jump animation
                animator.SetTrigger("jump");
                // apply our jump force to the Y axis
                // keep the horizontal velocity the same as before
                r.velocity = new Vector2(r.velocity.x, doubleJump ? doubleJumpPower : jumpForce);
                jbCounter = 0f;

                doubleJump = !doubleJump;
                
            }
        }

        if (Input.GetButtonUp("Jump") && r.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;
        }

     

        // pass the horizonal and vertical velocity to the animator
        animator.SetFloat("y", r.velocity.y);
        animator.SetFloat("x", moveInput);

        // face the appropriate direction
        if (moveInput < 0)
            sRenderer.flipX = true;
        else if (moveInput > 0)
            sRenderer.flipX = false;


        if (r.velocity.y < 0)
        {
            r.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier
                * Time.deltaTime;
        }
        else if (r.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            r.velocity += Vector2.up * Physics2D.gravity.y *
                lowJumpMultiplier * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canRollDash)
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
}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }

    public bool isGrounded()
    {
        return Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,
                collisionRadius,
                groundLayer);
    }

    private IEnumerator RollingDash()
    {       
        canRollDash = false;
        isRollDashing = true;
        float ogGravity = r.gravityScale;
        r.gravityScale = 0f;
        r.velocity = new Vector2(r.velocity.x * rollDashPower, 0f);
        trailRenderer.emitting = true;
        animator.SetTrigger("rolling");
        dashText.text = "Dashing...";
        yield return new WaitForSeconds(dashingTime);

        trailRenderer.emitting = false;
        r.gravityScale = ogGravity;
        isRollDashing = false;
        dashText.text = "Dash Unavailable";
        dashText.color = Color.red;
        yield return new WaitForSeconds(dashingCD);
        canRollDash = true;
        dashText.text = "Dash Available";
        dashText.color = Color.green;
    }

}




