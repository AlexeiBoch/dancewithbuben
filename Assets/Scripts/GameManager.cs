using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> playerList = new List<GameObject>();
    [SerializeField] List<string> ignoreDeleteTags;

    public static bool DoubleJumpUnlocked;
    public static bool PlayerReductionUnlocked;
    public static bool PlayerWizardUnlocked;

    private GameObject selectedPlayer;
    public GameObject SelectedPlayer
    {
        get 
        { 
            return selectedPlayer; 
        }
        set 
        {
            ChangeStatus(value);
            selectedPlayer = value;
        }
    }

    void Start()
    {
        StatusStart();
        SaveStart();
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedPlayer = playerList[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerReductionUnlocked)
            SelectedPlayer = playerList[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerWizardUnlocked)
            SelectedPlayer = playerList[2];
    }

    void StatusStart()
    {
        foreach (GameObject player in playerList)
            SetActiveExtended(player, false);
        SetActiveExtended(playerList[0], true);
        selectedPlayer = playerList[0];

    }

    void ChangeStatus(GameObject newSelectedPlayer)
    {
        foreach(GameObject player in playerList) 
        {
            if (player == newSelectedPlayer)
            {
                GameObject previousPlayer = selectedPlayer;
                player.transform.position = previousPlayer.transform.position;
                player.transform.rotation = previousPlayer.transform.localRotation;
                SetActiveExtended(player, true);
            }
            else SetActiveExtended(player, false);
        }
    }
    public void SetActiveExtended(GameObject player, bool value)
    {
        if (!value)
            foreach (Transform child in player.transform)
                if (!ignoreDeleteTags.Contains(child.gameObject.tag))
                    Destroy(child.gameObject);
        player.SetActive(value);
    }

    public static void UnlockAbility(string option)
    {
        switch (option)
        {
            case "doubleJump":
                {
                    DoubleJumpUnlocked = true;
                    return;
                }
            case "reduction":
                {
                    PlayerReductionUnlocked = true;
                    return;
                }
            case "wizard":
                {
                    PlayerWizardUnlocked = true;
                    return;
                }
        }
    }

    public void SaveStart()
    {
        if (SaveProgress.PlayerSaveExists())
            SelectedPlayer.GetComponent<PlayerController>().LoadPlayer();
        else
            SelectedPlayer.GetComponent<PlayerController>().SavePlayer();

        if (SaveProgress.GameSaveExists()) 
            LoadGame();
        else 
            SaveProgress.SaveGame();   
    }

    public void LoadGame()
    {
        DataSchemas.Game data = SaveProgress.LoadGame();
        DoubleJumpUnlocked = data.DoubleJumpUnlocked;
        PlayerReductionUnlocked = data.PlayerReductionUnlocked;
        PlayerWizardUnlocked = data.PlayerWizardUnlocked;
    }

    public void SaveFullProgress()
    {
        SaveProgress.SaveGame();
        SelectedPlayer.GetComponent<PlayerController>().SavePlayer();
    }

    private void OnApplicationQuit()
    {
        SaveFullProgress();
    }
}