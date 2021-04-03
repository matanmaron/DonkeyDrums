using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonkeyDrums.Data
{
    public class Settings
    {
        private const string FileName = "settings.json";

        public static GameData ImportSettings()
        {
            if (!File.Exists($"{Application.dataPath}/{FileName}"))
            {
                Debug.LogWarning("no settings file found, creating default");
                var data = new GameData();
                ExportSettings(data);
                return data;
            }
            string jsonImport = File.ReadAllText($"{Application.dataPath}/{FileName}");
            if (jsonImport == "{}")
            {
                Debug.LogWarning("settings file empty, creating default");
                var data = new GameData();
                ExportSettings(data);
                return data;
            }
            return JsonUtility.FromJson<GameData>(jsonImport);
        }
        static void ExportSettings(GameData settings)
        {
            string jsonExport = JsonUtility.ToJson(settings);
            File.WriteAllText($"{Application.dataPath}/{FileName}", jsonExport);
            Debug.Log("settings exported successfully");
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