using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float timeToLive;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
