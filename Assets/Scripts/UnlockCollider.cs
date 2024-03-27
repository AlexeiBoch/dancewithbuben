using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCollider : MonoBehaviour
{
    [SerializeField] string option;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.UnlockAbility(option);
            Destroy(gameObject);
        }
    }
}
