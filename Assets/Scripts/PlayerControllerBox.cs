using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControllerBox : PlayerController
{
    [SerializeField] GameObject effectSwiching;
    private GameObject effectSwichingScene;
    [SerializeField] bool proverkaNaDopusk = true;
    [SerializeField] float scaleFactor = 0.5f;
    [SerializeField] float raycastDistance = 1f;
    public Vector3 defaultScale;
    BoxCollider characterCollider;

    protected override void Start()
    {
        base.Start();
        characterTransform = transform;
        defaultScale = characterTransform.localScale;
        characterCollider = GetComponentInChildren<BoxCollider>(); // Получаем коллайдер персонажа
    }


    protected override void CheckAbilityKey()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ScaleSwitch();
            EffectSwitch();
        }
        DebugDrawRay();
    }

    private void EffectSwitch()
    {
        effectSwichingScene = Instantiate(effectSwiching, transform.position, Quaternion.identity);
        Destroy(effectSwichingScene, 1f);
    }

    private void DebugDrawRay()
    {
        Vector3 rayOrigin = characterTransform.position + Vector3.up * characterCollider.bounds.extents.y;
        Vector3 rayDirection = Vector3.up;
        Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.green);
    }

    private void ScaleSwitch()
    {
        RaycastHit hit;
        Vector3 rayOrigin = characterTransform.position + Vector3.up * characterCollider.bounds.extents.y;
        Vector3 rayDirection = Vector3.up;

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
        {
            proverkaNaDopusk = false;
            return;
        }

        if (!proverkaNaDopusk)
        {
            if (characterTransform.localScale != defaultScale)
                characterTransform.localScale = defaultScale;
            else
                characterTransform.localScale *= scaleFactor;
        }
    }
}