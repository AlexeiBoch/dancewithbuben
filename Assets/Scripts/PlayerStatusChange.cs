using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatusChange : MonoBehaviour
{
    [SerializeField] List<GameObject> playerList = new List<GameObject>();

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && playerList[0].GetComponent<PlayerController>().Unlocked)
            SelectedPlayer = playerList[0];
        if (Input.GetKeyDown(KeyCode.Alpha2) && playerList[1].GetComponent<PlayerController>().Unlocked)
            SelectedPlayer = playerList[1];
        if (Input.GetKeyDown(KeyCode.Alpha3) && playerList[2].GetComponent<PlayerController>().Unlocked)
            SelectedPlayer = playerList[2];
    }

    void StatusStart()
    {
        foreach (GameObject player in playerList)
            player.SetActive(false);
        playerList[0].SetActive(true);
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
                player.SetActive(true);
            }
            else player.SetActive(false);
        }
    }
}