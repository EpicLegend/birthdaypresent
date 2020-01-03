using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    private Animator anim;

    public int count;
    public Text text;
    public Image text_a;
    public Image text_space;
    public Image text_d;
    public Image text_e;

    private Color colorBase;
    private Color colorBaseOther;

    public AudioClip din;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        text.text = count.ToString();

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        extraJumps = extraJumpValue;

        colorBase = new Color(1.0f, 1.0f, 1.0f, 0.6941177f);
        colorBaseOther = new Color(1.0f, 1.0f, 1.0f, 0.6941177f);

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        actionInput();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput*speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
            
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
            

        if (isGrounded) {
            extraJumps = extraJumpValue;
        }




        // animation
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ) {
            // walk and jump

            if (isGrounded)
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isJump", false);
            }
            else {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJump", true);
            }
        }  else {
            // idle and jump
            
            if (isGrounded)
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJump", false);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isJump", true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && !isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        else if (isGrounded && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        { 
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "count")
        {
            audio.Play();
            Destroy(other.gameObject);
            count--;
            text.text = count.ToString();
        }

        if (other.tag == "precent" && count == 0)
        {
            colorBaseOther = new Color(0.549f, 0.8392f, 0.0f, 1.0f);
        }
        else {
            colorBaseOther = new Color(1.0f, 1.0f, 1.0f, 0.6941177f);
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }


    private void actionInput()
    {

        if (Input.GetKey(KeyCode.A))
            text_a.color = new Color(0.48f, 0.219f, 0.94f, 1.0f);
        else
            text_a.color = colorBase;


        if (Input.GetKey(KeyCode.D))
            text_d.color = new Color(0.48f, 0.219f, 0.94f, 1.0f);
        else
            text_d.color = colorBase;


        if (Input.GetKey(KeyCode.E))
            text_e.color = new Color(0.48f, 0.219f, 0.94f, 1.0f);
        else
            text_e.color = colorBaseOther;

        if (Input.GetKey(KeyCode.Space))
            text_space.color = new Color(0.48f, 0.219f, 0.94f, 1.0f);
        else
            text_space.color = colorBase;
    }
}
