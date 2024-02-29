using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class PlayerControllerBox : PlayerController
{
    [SerializeField] GameObject box;
    [SerializeField] GameObject boxPreview;
    [SerializeField] float spawnDistance = 2.5f;
    [SerializeField] float spawnHeight;
    GameObject previousBox;
    Vector3 previousSpawnPos;

    protected override void CheckAbilityKey()
    {
        if (Input.GetKey(KeyCode.E))
            Ability();
        if (Input.GetKeyUp(KeyCode.E))
            Ability(true);
    }

    protected void Ability(bool put = false)
    {
        GameObject player = gameObject;
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        Vector3 spawnPos = new Vector3(playerPos.x + spawnDistance * playerDirection.z, playerPos.y + spawnHeight, 0);
        if (put)
        {
            Destroy(previousBox);
            previousBox = Instantiate(box, spawnPos, playerRotation);
        }
        else
        {
            if (previousSpawnPos != null && previousSpawnPos == spawnPos)
                return;
            if (previousBox != null)
                Destroy(previousBox);
            previousSpawnPos = spawnPos;
            previousBox = Instantiate(boxPreview, spawnPos, playerRotation);
        }
    }
}