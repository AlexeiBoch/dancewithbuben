using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScroll : MonoBehaviour
{
    [SerializeField] GameObject PapersScroll;
    private bool playerInCollider = false;
    [SerializeField] GameObject ScrollText;
    [SerializeField] GameObject Scroll;
    [SerializeField] GameObject PanelScroll;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerInCollider = false;
        }
    }

    void Update()
    {
        if (playerInCollider && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("записка работает");
            PapersScroll.SetActive(true);
            ScrollText.SetActive(false);
            Scroll.SetActive(false);
            PanelScroll.SetActive(true);
            Time.timeScale = 0f;
           

        }
    }

    public void CLosePapersScroll()
    {
        PapersScroll.SetActive(false);
        Time.timeScale = 1f;
        Scroll.SetActive(true);
        ScrollText.SetActive(true);
        PanelScroll.SetActive(false);
    }
}


