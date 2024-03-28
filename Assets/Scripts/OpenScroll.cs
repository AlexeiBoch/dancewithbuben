using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenScroll : Sounds
{
    
    private bool playerInCollider = false;
    [SerializeField] GameObject ScrollText;
    [SerializeField] GameObject Scroll;
    [SerializeField] GameObject PanelScrollBack;

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
            ScrollText.SetActive(false);
            Scroll.SetActive(false);
            PanelScrollBack.SetActive(true);
            Time.timeScale = 0f;
                PlaySound(sounds[0], destroyed: true, voulume: voulume1);
        }
    }

    public void CLosePanelScroll()
    {
        
        Scroll.SetActive(true);
        ScrollText.SetActive(true);
        PanelScrollBack.SetActive(false);
        Time.timeScale = 1f;
    }
}


