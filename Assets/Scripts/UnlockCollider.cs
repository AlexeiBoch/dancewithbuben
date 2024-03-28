using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class UnlockCollider : MonoBehaviour
{
    [SerializeField] string option;
    [SerializeField] GameObject TextUnLockAbility;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TextUnLockAbility.SetActive(true);
            GameManager.UnlockAbility(option);
            Time.timeScale = 0f;
            
        }
    }
    public void CloseTextUnLockAbility()
    {
        TextUnLockAbility.SetActive(false);
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
