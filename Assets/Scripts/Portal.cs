using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Sounds
{

    [SerializeField] private Portal toPoartal;
    public static bool tpActive;

    public GameObject effectPortal;
    GameObject effectDie;
    void Start()
    {
        tpActive = true;
        Vector3 spawnPosition = transform.position - new Vector3(0, 0, 0);
        effectDie = Instantiate(effectPortal, spawnPosition, Quaternion.identity);
        //Destroy(effectDie, 1f);
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
            PlaySound(sounds[0], destroyed: true, voulume: voulume1);
        }


        else
        {
            tpActive = true;
            PlaySound(sounds[0], destroyed: true, voulume: voulume1);
        }
    }


}
