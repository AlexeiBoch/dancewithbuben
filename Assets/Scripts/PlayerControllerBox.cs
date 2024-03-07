using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerBox : PlayerController
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject boxPreview;
    [SerializeField] public float spawnDistance;
    [SerializeField] public float spawnHeight;
    private GameObject previousBox;
    private GameObject previousBoxPreview;

    protected override void CheckAbilityKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Ability("start");
        if (Input.GetKeyUp(KeyCode.E))
            Ability("place");
    }

    protected void Ability(string action)
    {
        GameObject player = gameObject;
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        Vector3 spawnPos = new Vector3(playerPos.x + spawnDistance * playerDirection.z, playerPos.y + spawnHeight, 0);
        float boxHalfOfSize = boxPreview.GetComponent<SpriteRenderer>().bounds.size.x / 2f + 0.0001f;
        switch (action)
        {
            case "start":
                {
                    previousBoxPreview = Instantiate(boxPreview, spawnPos, playerRotation);
                    previousBoxPreview.transform.parent = player.transform;
                    break;
                }
            case "place":
                {
                    if (previousBox)
                        Destroy(previousBox);
                    Destroy(previousBoxPreview);
                    if(BoxScript.canBuild)
                        previousBox = Instantiate(box, previousBoxPreview.transform.position, playerRotation);
                    break;
                }
        }
        
    }
}