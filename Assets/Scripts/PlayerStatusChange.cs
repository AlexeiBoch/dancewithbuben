using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatusChange : MonoBehaviour
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedPlayer = playerList[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && SaveProgress.data["PlayerReductionUnlocked"] == 1)
            SelectedPlayer = playerList[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && SaveProgress.data
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
        Player
    }
}