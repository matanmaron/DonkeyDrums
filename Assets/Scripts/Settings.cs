using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonkeyDrums.Data
{
    public class Settings
    {
        public static GameData ImportSettings()
        {
            var gameData = new GameData();
            gameData.stopSpeed = PlayerPrefs.GetFloat("stopSpeed", 0.05f);
            gameData.maxSpeed = PlayerPrefs.GetFloat("maxSpeed", 5f);
            gameData.speedBumps = PlayerPrefs.GetFloat("speedBumps", 1f);
            gameData.jumpForce = PlayerPrefs.GetFloat("jumpForce", 9f);
            return gameData;
        }
        public static void ExportSettings(GameData settings)
        {
            PlayerPrefs.SetFloat("stopSpeed", settings.stopSpeed);
            PlayerPrefs.SetFloat("maxSpeed", settings.maxSpeed);
            PlayerPrefs.SetFloat("speedBumps", settings.speedBumps);
            PlayerPrefs.SetFloat("jumpForce", settings.jumpForce);
        }
    }

    [Serializable]
    public class GameData
    {
        public float stopSpeed = 0.05f;
        public float maxSpeed = 5;
        public float speedBumps = 1;
        public float jumpForce = 12;

        public override string ToString()
        {
            return $"stopSpeed:{stopSpeed} | maxSpeed:{maxSpeed} | speedBumps:{speedBumps} | jumpForce:{jumpForce}";
        }
    }
}