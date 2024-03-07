using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SettingsGameManager : MonoBehaviour
{
    [SerializeField] GameObject PanelMenu;
    [SerializeField] GameObject settings;

    public void OpenPanel()
    {
        PanelMenu.SetActive(!PanelMenu.activeSelf);
    }

    public void OpenSettings()
    {
        PanelMenu.SetActive(false);
        settings.SetActive(!settings.activeSelf);
    }

    public void PlayGame()
    {
        PanelMenu.SetActive(false);
    }
    public void ClosePanel()
    {
        PanelMenu.SetActive(false);
    }

    public void CloseSattings()
    {
        PanelMenu.SetActive(true);
        settings.SetActive (false);
    }
    public void ExitToStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
