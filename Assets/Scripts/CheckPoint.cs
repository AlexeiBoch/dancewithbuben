using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint:MonoBehaviour
{
    PlayerController playerController;
    public GameObject touchEffect;
    GameObject bufferEffect;
    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerController.UpdateCheckPoint(transform.position);

            Vector3 spawnPosition = transform.position - new Vector3(0, 0, 0);
            bufferEffect = Instantiate(touchEffect, spawnPosition, Quaternion.identity);
            Destroy(bufferEffect, 1f);
        }
    }
}
