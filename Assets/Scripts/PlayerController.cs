using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    // Start is called before the first frame update
    private Rigidbody2D rb;//플레이어의 리지드 바디 변수 
    [SerializeField] private float walkSpeed = 1;// 플레이어가 걷는 속도
    private float xAxis = 0; // x축 움직음
    Animator anim;
    private bool canDash =true;
    private bool dashed =false;

    [Header("Vertical Movemnet Settings")]
    [SerializeField]private float jumpForce = 45f;
    private int jumpBufferCounter;
    [SerializeField] private int JumpBufferFrames;
    private float coyoteTimeCounter = 0;
    [SerializeField] private float coyoteTime;
    private int airJumpCounter = 0;
    [SerializeField] private int maxAirJumps;


    [Header("Ground Check Settings")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;
    [SerializeField] private float groundCheckX = 0.5f;
    [SerializeField] private LayerMask whatIsGround;
    
    [Header("Dash Settings")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCooldown;
    [SerializeField] GameObject dashEffect;


    PlaYerStateList pstate;
    private float yAxis = 0; // x축 움직음
    private float gravity;
    public static PlayerController instance;
    [Header("SoundControl")]
    public AudioClip jumpSound;
    public AudioSource audioSource;
    public bool b_firstLanding = false;  
    private void Awake()
    {
        if(instance != null && instance != this) 
        { 
           Destroy(gameObject );
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        pstate =GetComponent<PlaYerStateList>();
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        anim = GetComponent<Animator>();
        gravity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        UpdateJumpVariables();
        if (pstate.dashing)return;
        Flip();// 캐릭터 방향전환 
        Move();// 캐릭터 이동
        Jump();// 캐릭터 점프
        StartDash();
        

    }

    void GetInputs()
    {
        
        xAxis = Input.GetAxis("Horizontal");
       
    }

    private void Move()
    {
        rb.velocity = new Vector2(walkSpeed *xAxis,rb.velocity.y);
        anim.SetBool("Walking",rb.velocity.x != 0 && Grounded());
    }
    void StartDash()
    {
        if(Input.GetButtonDown("Dash")&& canDash && !dashed)
        {
            //StartCoroutine(Dash());
            dashed = true;

        }

        if(Grounded())
        {
            dashed = false;
        }
    }
    IEnumerator Dash() 
    {
        canDash = false;
        pstate.dashing = true;
        anim.SetTrigger("Dashing");
        rb.gravityScale = 0;
        rb.velocity = new Vector2(transform.localScale.x * dashSpeed, 0);
        if (Grounded()) Instantiate(dashEffect,transform);
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = gravity;
        pstate.dashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    void Flip()//방향 바꾸기
    {
        if(xAxis < 0)
        {
            transform.localScale = new Vector2(-1,transform.localScale.y);
        }
        else if(xAxis >0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
    }
    public bool Grounded()
    { 
        if(Physics2D.Raycast(groundCheckPoint.position,Vector2.down,groundCheckY,whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX,0,0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX, 0, 0), Vector2.down, groundCheckY, whatIsGround))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&rb.velocity.y>0)  //makes player jump
        {
            audioSource.PlayOneShot(jumpSound);
            rb.velocity = new Vector3(rb.velocity.x, 0);
            pstate.jumping = false;
        }
       
        if (!pstate.jumping)
        {
            if (jumpBufferCounter > 0 && coyoteTimeCounter > 0)  //makes player jump
            {
                audioSource.PlayOneShot(jumpSound);
                
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
                pstate.jumping = true;
            }
            else if(!Grounded() && airJumpCounter < maxAirJumps &&Input.GetButtonDown("Jump"))
            {
                pstate.jumping = true;
                airJumpCounter++;
                rb.velocity = new Vector3(rb.velocity.x,jumpForce );
            }
        }
        anim.SetBool("Jumping", !Grounded());
       
    }

    void UpdateJumpVariables()
    {
        if (Grounded())
        { 
            pstate.jumping = false;
            coyoteTimeCounter = coyoteTime;
            airJumpCounter = 0;
        }
        else
        {
            coyoteTimeCounter -=Time.deltaTime;
        }
        if(Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = JumpBufferFrames;
        }
        else
        {
            jumpBufferCounter--;    
        }
    }
}

