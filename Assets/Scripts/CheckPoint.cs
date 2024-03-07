using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameControler gameControler;

    private void Awake()
    {
        gameControler = GameObject.FindGameObjectWithTag("Player").GetComponent<GameControler>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            gameControler.UpdateCheckPoint(transform.position);
        }
    }
}
