using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint:MonoBehaviour
{
    GameControler gameControler;
    public GameObject touchEffect;
    GameObject bufferEffect;
    
    private void Awake()
    {
        gameControler = GameObject.FindGameObjectWithTag("Player").GetComponent<GameControler>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            gameControler.UpdateCheckPoint(transform.position);

            Vector3 spawnPosition = transform.position - new Vector3(0, 0, 0);
            bufferEffect = Instantiate(touchEffect, spawnPosition, Quaternion.identity);
            Destroy(bufferEffect, 1f);
        }
    }
}
