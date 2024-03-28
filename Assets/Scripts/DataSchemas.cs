using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSchemas
{
    [System.Serializable]
    public class Player
    {
        public float[] position;

        public Player (PlayerController player)
        {
            position = new float[3];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
            position[2] = player.transform.position.z;
        }
    }
    [System.Serializable]
    public class Game
    {
        public bool DoubleJumpUnlocked;
        public bool PlayerReductionUnlocked;
        public bool PlayerWizardUnlocked;
        public Game()
        {
            DoubleJumpUnlocked  = GameManager.DoubleJumpUnlocked;
            PlayerReductionUnlocked = GameManager.PlayerReductionUnlocked;
            PlayerWizardUnlocked = GameManager.PlayerWizardUnlocked;
        }
    }
}
