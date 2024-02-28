using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGameManager : MonoBehaviour
{
    [SerializeField] GameObject settings;
    
   public void OpenSettings()
    {
        settings.SetActive(!settings.activeSelf);
    }
}
