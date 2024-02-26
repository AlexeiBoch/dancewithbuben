using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] private Portal toPoartal;
    public static bool tpActive;
    void Start()
    {
        tpActive = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

        if (tpActive)
        {
            tpActive = false;
            float magnitude  = rb.velocity.magnitude;
            rb.velocity = Vector3.zero;
            Vector3 direction = toPoartal.transform.TransformDirection(Vector3.right) - transform.TransformDirection(Vector3.left);
            other.transform.position = toPoartal.transform.position;
            rb.AddForce(direction * magnitude, ForceMode2D.Impulse);
        }

     
        else
            tpActive = true;
    }


}
