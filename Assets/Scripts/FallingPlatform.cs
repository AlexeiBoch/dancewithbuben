using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 currentPosition;
    bool moveIngBack;
    [SerializeField] float FallingPlatformTime;
    [SerializeField] float BackPlatformTime;
    [SerializeField] float fallingSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && moveIngBack == false)
        {
            Invoke("FallPlatform", FallingPlatformTime);
            
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
        Invoke("BackPlatform", BackPlatformTime);
    }

    void BackPlatform()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        moveIngBack = true;
    }

    private void Update()
    {
        if (moveIngBack == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPosition, fallingSpeed * Time.deltaTime);

            if(transform.position.y == currentPosition.y)
            {
                moveIngBack = false;
            }
        }
    }

}
