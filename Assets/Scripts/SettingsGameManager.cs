using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class  SettingsGameManager : MonoBehaviour
{
    [SerializeField] GameObject PanelMenuBack;
    [SerializeField] GameObject PanelSettingsBack;
    [SerializeField] GameObject PausePanelBack;
    [SerializeField] GameObject PanelScrollBack;

    public void OpenPanel()
    {
        if (!(PausePanelBack.activeSelf)&& !(PanelScrollBack.activeSelf))
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
        PanelSettingsBack.SetActive (false);
    }
    public void ExitToStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
