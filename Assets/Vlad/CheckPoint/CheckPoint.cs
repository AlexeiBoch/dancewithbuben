using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int index;
    void Start()
    {
        
    }

    
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        if(DataContainer.CheckPointIndex == index)
        {
            player.position = transform.position;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            DataContainer.CheckPointIndex = index;
        }
    }
}
