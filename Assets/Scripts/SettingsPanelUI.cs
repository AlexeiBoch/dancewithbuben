using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsPanelUI : MonoBehaviour
{
    [SerializeField] GameObject PanelMenuBack;
    [SerializeField] GameObject PanelSettingsBack;
    [SerializeField] GameObject PausePanelBack;
    [SerializeField] GameObject[] PanelScrollBack;
    [SerializeField] GameObject[] TextUnlockAbility;
    [SerializeField] GameObject PanelStartGame;

    private void Start()
    {
        PanelStartGame.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OpenPanel()
    {
        if (!(PausePanelBack.activeSelf) && !(PanelStartGame.activeSelf) && !(PanelSettingsBack.activeSelf))
        {
            if(!(PanelScrollBack[0].activeSelf) && !(PanelScrollBack[1].activeSelf) && !(PanelScrollBack[2].activeSelf))
            {
                if (!(TextUnlockAbility[0].activeSelf) && !(TextUnlockAbility[1].activeSelf))
                {
                    PanelMenuBack.SetActive(!PanelMenuBack.activeSelf);
                }
            }
            
        }
        Time.timeScale = 0f;

    }

    public void StartGame()
    {
        PanelStartGame.SetActive(false);
        Time.timeScale = 1f;
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
        Time.timeScale = 0f;
        PanelMenuBack.SetActive(false);
        PanelStartGame.SetActive(true);
    }
}

