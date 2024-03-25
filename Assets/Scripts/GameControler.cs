using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameControler : MonoBehaviour
{
    Vector2 checpointPos;
    [SerializeField] GameObject PausePanel;
    

    private void Start()
    {
        checpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Trap"))
        {
            Die();
        }
    }
    void Die()
    {
        PausePanel.SetActive(!PausePanel.activeSelf);
        Time.timeScale = 0f;
        
    }
    public void ClosePanelPause()
    {
        PausePanel.SetActive(false);
        Respawn();
        Time.timeScale = 1f;
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checpointPos = pos;
    }
    void Respawn()
    {
        transform.position = checpointPos;
    }

    public static implicit operator GameControler(Collider2D v)
    {
        throw new NotImplementedException();
    }
}
