using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController: MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Animator anim;
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
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Grounds"))
        {
            isGrounded = true;
            anim.SetBool("onGround", isGrounded);
        }        
    }

    [SerializeField] private float speed;
    [SerializeField] Vector2 moveVector;
    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX",Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

    [SerializeField] private float jumpForce;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetBool("onGround", !isGrounded);
            isGrounded = false;
        }
    }

    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

}
