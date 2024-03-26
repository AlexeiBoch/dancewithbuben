using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Transform[] moveSports;
    private int randomSports;
    private float waitTime;
    [SerializeField] float startWaitTime;

    void Start()
    {
        randomSports = Random.Range(0, moveSports.Length);
        waitTime = startWaitTime;
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSports[randomSports].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSports[randomSports].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSports = Random.Range(0, moveSports.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
