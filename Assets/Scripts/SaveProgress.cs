using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using UnityEditor;

public static class SaveProgress
{
    public static string PlayerSavePath = Application.persistentDataPath + "/Player.save";
    public static string GameSavePath = Application.persistentDataPath + "/Game.save";
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(PlayerSavePath, FileMode.Create);
        DataSchemas.Player data = new DataSchemas.Player(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataSchemas.Player LoadPlayer()
    {
        if (File.Exists(PlayerSavePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(PlayerSavePath, FileMode.Open);
            DataSchemas.Player data = formatter.Deserialize(stream) as DataSchemas.Player;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + PlayerSavePath);
            return null;
        }
    }
    public static bool PlayerSaveExists()
    {
        return File.Exists(PlayerSavePath);
    }


    public static void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(GameSavePath, FileMode.Create);
        DataSchemas.Game data = new DataSchemas.Game();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataSchemas.Game LoadGame()
    {
        if (File.Exists(GameSavePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(GameSavePath, FileMode.Open);
            DataSchemas.Game data = formatter.Deserialize(stream) as DataSchemas.Game;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + GameSavePath);
            return null;
        }
    }
    public static bool GameSaveExists()
    {
        return File.Exists(GameSavePath);
    }
}