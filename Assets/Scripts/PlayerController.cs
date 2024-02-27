using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController:Sounds
{
    public bool Unlocked;
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] PlayerStatusChange PlayerStatusChange;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
        Jump();
        Flip();
    }

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private GameObject effectLanding;
    private GameObject effectLandingInstance;   
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Trap"))
        { }

        if (coll.gameObject.CompareTag("Grounds"))
        {
            isGrounded = true;
            anim.SetBool("onGround", isGrounded);

            effectLandingInstance = Instantiate(effectLanding, transform.position - new Vector3(0, 0.9f, 0), Quaternion.identity);
            PlaySound(sounds[3], voulume:0.1f , destroyed: true);
            Destroy(effectLandingInstance, 1f);
        }
    }

    [SerializeField] private float speed;
    [SerializeField] Vector2 moveVector; 

    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    [SerializeField] private float jumpForce;

    [SerializeField] private float doubleJumpForce;
    private bool hasDoubleJumped = false;

    [SerializeField] private GameObject effectJump;
    private GameObject effectJumpInstance;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                PlaySound(sounds[0], destroyed: true, voulume:0.3f);
                rb.AddForce(Vector2.up * jumpForce);
                anim.SetBool("onGround", false);
                isGrounded = false;
                hasDoubleJumped = false;
            }
            else if (!hasDoubleJumped)
            {
                PlaySound(sounds[1], destroyed: true, voulume: 0.3f);
                rb.velocity = new Vector2(rb.velocity.x, 0f); 
                rb.AddForce(Vector2.up * doubleJumpForce);
                hasDoubleJumped = true;

                Vector3 spawnPosition = transform.position - new Vector3(0, 1.5f, 0);
                effectJumpInstance = Instantiate(effectJump, spawnPosition, Quaternion.identity);
                Destroy(effectJumpInstance, 1f);
            }
        }
    }   

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    void ObxodSounds()
    {
        PlaySound(sounds[2], destroyed: true, voulume: 0.3f);
        PlaySound(sounds[4], destroyed: true, voulume: 0.05f);
    }   
}