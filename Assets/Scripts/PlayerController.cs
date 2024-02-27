using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
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
    [SerializeField] private GameObject effectLanding;
    private GameObject effectLandingInstance;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        // сделал Влад тут короче касание с шипом по тэгу
        if (coll.gameObject.CompareTag("Trap"))
        {
            Debug.Log("плэер помер");
        }
       // Сделал Влад

        if (coll.gameObject.CompareTag("Grounds"))
        {
            isGrounded = true;
            anim.SetBool("onGround", isGrounded);

                effectLandingInstance = Instantiate(effectLanding, transform.position - new Vector3(0, 0.9f, 0), Quaternion.identity);
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

    [SerializeField] private float doubleJumpForce; // Сила для двойного прыжка
    private bool hasDoubleJumped = false; // Флаг для отслеживания использования двойного прыжка

    [SerializeField] private GameObject effectJump;
    private GameObject effectJumpInstance;
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                // Если на земле, прыгаем обычным образом
                rb.AddForce(Vector2.up * jumpForce);
                anim.SetBool("onGround", false);
                isGrounded = false;
                hasDoubleJumped = false; // Обнуляем флаг двойного прыжка
            }
            else if (!hasDoubleJumped)
            {
                // Если в воздухе и не использовали двойной прыжок
                rb.velocity = new Vector2(rb.velocity.x, 0f); // Сбрасываем вертикальную скорость
                rb.AddForce(Vector2.up * doubleJumpForce);
                hasDoubleJumped = true; // Устанавливаем флаг двойного прыжка в true

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
}
