using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanelUI : MonoBehaviour
{
    [SerializeField] GameObject PanelMenuBack;
    [SerializeField] GameObject PanelSettingsBack;
    [SerializeField] GameObject PausePanelBack;
    [SerializeField] GameObject PanelScrollBack;
    [SerializeField] GameObject PanelStartGame;

    public void OpenPanel()
    {
        if (!(PausePanelBack.activeSelf) && !(PanelScrollBack.activeSelf) && !(PanelStartGame.activeSelf) && !(PanelSettingsBack.activeSelf))
        {
            PanelMenuBack.SetActive(!PanelMenuBack.activeSelf);
        }
        Time.timeScale = 0f;

    }

    public void OpenSettings()
    {
        PanelMenuBack.SetActive(false);
        PanelSettingsBack.SetActive(!PanelSettingsBack.activeSelf);
    }

    public void PlayGame()
    {
        PanelMenuBack.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ClosePanel()
    {
        PanelMenuBack.SetActive(false);
        Time.timeScale = 1f;

    }

    public void CloseSattings()
    {
        PanelMenuBack.SetActive(true);
        PanelSettingsBack.SetActive(false);
    }
    public void ExitToStartGame()
    {
        PanelStartGame.SetActive(true);
    }
}

