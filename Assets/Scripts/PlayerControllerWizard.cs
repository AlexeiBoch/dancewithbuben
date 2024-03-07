using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerWizard : PlayerController
{
    [SerializeField] GameObject PlayerProjectile;
    [SerializeField] float projectileSpawnOffsetWidth;
    [SerializeField] float projectileSpawnOffsetHeight;

    protected override void Ability()
    {
        Vector3 playerPos = gameObject.transform.position;
        Vector3 playerDirection = gameObject.transform.forward;
        Quaternion playerRotation = gameObject.transform.rotation;
        Vector3 offsets = new Vector3(projectileSpawnOffsetWidth * playerDirection.z, projectileSpawnOffsetHeight);
        Vector3 spawnPos = playerPos;
        Instantiate(PlayerProjectile, spawnPos + offsets, playerRotation);
        // добавить анммку
    }
}