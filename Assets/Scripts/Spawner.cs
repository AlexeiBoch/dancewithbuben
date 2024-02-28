using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float SpawnDelay;
    [SerializeField] float spawnX;
    [SerializeField] float spawnY;
    [SerializeField] float DestryObject;
    private float randomX;
    Vector2 whereToSpawn;
    float nextSpawn = 0.0f;


    
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnDelay;
            randomX = Random.Range(spawnX,spawnY);
            whereToSpawn = new Vector2(randomX, transform.position.y); 
            GameObject Enemy = Instantiate(obj, whereToSpawn, Quaternion.identity);
            Destroy(Enemy,DestryObject);
        }
        
    }
}
