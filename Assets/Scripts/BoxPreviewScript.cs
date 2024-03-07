using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPreviewScript : MonoBehaviour
{
    private float boxHalfOfSize;

    public static bool canBuild;

    public bool CanBuild { 
        get 
        { return canBuild; } 
        set 
        {
            if (canBuild == value)
            { }
            else
            {
                if (value)
                    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                else
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.5f);
                canBuild = value;
            }
        }
    }

    private void Start()
    {
        boxHalfOfSize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2f + 0.0001f;
        CanBuild = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 0.5f);
    }


    public void Update()
    {
        CheckRayHits();
    }

    public void CheckRayHits()
    {
        Vector3 boxPos = gameObject.transform.position;
        Vector3 rayDirection = transform.right;
        float rayDistance = boxHalfOfSize;
        RaycastHit2D hitToWall = Physics2D.Raycast(boxPos, rayDirection, rayDistance);
        RaycastHit2D hitBoxRayCollider = Physics2D.Raycast(boxPos, rayDirection, boxHalfOfSize);
        Debug.DrawRay(boxPos, rayDirection * boxHalfOfSize, Color.red);
        if (hitBoxRayCollider.collider)
            CanBuild = false;
        else
            CanBuild = true;
        if (hitToWall.collider)
        {
            gameObject.transform.localPosition -= new Vector3(0.1f, 0);
        }
    }
}
