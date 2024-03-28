using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveTools
{
    [MenuItem("Tools/SaveProgress/Delete Player.save")]
    public static void DeletePlayerSave()
    {
        if (File.Exists(SaveProgress.PlayerSavePath))
            File.Delete(SaveProgress.PlayerSavePath);
    }

    [MenuItem("Tools/SaveProgress/Delete Game.save")]
    public static void DeleteGameSave()
    {
        if (File.Exists(SaveProgress.GameSavePath))
            File.Delete(SaveProgress.GameSavePath);
    }

    [MenuItem("Tools/SaveProgress/Delete all")]
    public static void DeleteAddSaves()
    {
        DeletePlayerSave();
        DeleteGameSave();
    }
}
