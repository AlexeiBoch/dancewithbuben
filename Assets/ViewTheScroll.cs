using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTheScroll : MonoBehaviour
{
    [SerializeField] GameObject ScollText;
  
    private void OnTriggerEnter2D(Collider2D coll)
    {
   
        if (coll.CompareTag("Player"))
        {
            ScollText.SetActive(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ScollText.SetActive(false);
    }
}
