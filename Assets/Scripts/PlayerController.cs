using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController:Sounds
{
    public Rigidbody2D rb;
    [SerializeField] private Animator anim;
    public Transform characterTransform;

    public int money = 1;
    static Vector2 checpointPos;
    [SerializeField] GameObject PausePanel;

    //перенос GameController
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Trap"))
        {
            Die();
        }
    }
    void Die()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        Time.timeScale = 0f;

    }
    public void ClosePanelPause()
    {
        PausePanel.SetActive(false);
        Respawn();
        Time.timeScale = 1f;
        
    }

    public  void UpdateCheckPoint(Vector2 pos)
    {
        checpointPos = pos;
    }
    public void Respawn()
    {
        transform.position = checpointPos;
    }
    //перенос GameController

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checpointPos = transform.position;
        
    }

    protected virtual void Update()
    {
        Walk();
        Jump();
        Flip();
        CheckAbilityKey();
    }

    protected virtual void CheckAbilityKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ability();
        }
    }
    
    protected virtual void Ability()
    {
        
    }

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private GameObject effectLanding;
    private GameObject effectLandingInstance;   
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Trap"))
        { }
        if (coll.gameObject.CompareTag("Grounds") || coll.gameObject.CompareTag("Box"))
        {
            isGrounded = true;
            anim.SetBool("onGround", isGrounded);

            effectLandingInstance = Instantiate(effectLanding, transform.position - new Vector3(0, 0.9f, 0), Quaternion.identity);
            PlaySound(sounds[3], voulume: voulume1, destroyed: true);
            Destroy(effectLandingInstance, 1f);
        }
    }

    [SerializeField] public float speed;
    [SerializeField] Vector2 moveVector; 

    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    [SerializeField] protected float jumpForce;

    [SerializeField] protected float doubleJumpForce;
    private bool hasDoubleJumped = false;

    [SerializeField] private GameObject effectJump;
    private GameObject effectJumpInstance;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                PlaySound(sounds[0], destroyed: true, voulume: voulume1);
                rb.AddForce(Vector2.up * jumpForce);
                anim.SetBool("onGround", false);
                isGrounded = false;
                hasDoubleJumped = false;
            }
            else if (!hasDoubleJumped)
            {
                PlaySound(sounds[1], destroyed: true, voulume : voulume1);
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
        PlaySound(sounds[2], destroyed: true, voulume: voulume1);
        PlaySound(sounds[4], destroyed: true, voulume: voulume1);
    }
}