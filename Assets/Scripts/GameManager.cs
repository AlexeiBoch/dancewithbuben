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

    static void SaveStart()
    {
        string savePath = "PlayerProgress.save";
        if (File.Exists(savePath))
        {
            SaveProgress.LoadData();
        }
        else
        {
            SaveProgress.data["PlayerReductionUnlocked"] = 0;
            SaveProgress.data["PlayerWizardUnlocked"] = 0;
            SaveProgress.SaveData();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedPlayer = playerList[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && SaveProgress.data["PlayerReductionUnlocked"] == 1)
            SelectedPlayer = playerList[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && SaveProgress.data["PlayerWizardUnlocked"] == 1)
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

    public void UnlockPlayer(int playerId)
    {
        switch (playerId)
        {
            case 1:
                {
                    SaveProgress.data["PlayerReductionUnlocked"] = 1;
                    return;
                }
            case 2:
                {
                    SaveProgress.data["PlayerWizardUnlocked"] = 1;
                    return;
                }
        }
    }

    private void OnApplicationQuit()
    {
        SaveProgress.SaveData();
    }
}