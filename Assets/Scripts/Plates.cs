using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    [SerializeField] GameObject door;
    private int CountOfObjectsOnColl;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
            CountOfObjectsOnColl += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player"))
            CountOfObjectsOnColl -= 1;
        if (CountOfObjectsOnColl == 0)
            door.SetActive(true);
    }
}
