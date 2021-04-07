using DonkeyDrums.Core;
using DonkeyDrums.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DonkeyDrums.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI CoinText = null;
        [SerializeField] GameObject SettingsPanel = null;
        [SerializeField] TMP_InputField StopSpeed = null;
        [SerializeField] TMP_InputField MaxSpeed = null;
        [SerializeField] TMP_InputField SpeedBumps = null;
        [SerializeField] TMP_InputField JumpForce = null;
        [SerializeField] TextMeshProUGUI ErrorText = null;
        [SerializeField] TextMeshProUGUI Wintext = null;
        GameData data => GameManager.Instance.data;

        internal void ShowCoins(int coins)
        {
            CoinText.text = coins.ToString();
        }

        internal void ToggleSettings()
        {
            if (SettingsPanel.activeSelf)
            {
                SettingsPanel.SetActive(false);
                SaveSettings();
            }
            else
            {
                SettingsPanel.SetActive(true);
                LoadSettings();
            }
        }

        private void SaveSettings()
        {
            try
            {
                data.stopSpeed = float.Parse(StopSpeed.text);
                data.maxSpeed = float.Parse(MaxSpeed.text);
                data.speedBumps = float.Parse(SpeedBumps.text);
                data.jumpForce = float.Parse(JumpForce.text);
                Settings.ExportSettings(data);
            }
            catch (Exception ex)
            {
                ErrorText.text = ex.ToString();
            }
        }

        internal void YouWin()
        {
            Wintext.gameObject.SetActive(true);
        }

        private void LoadSettings()
        {
            StopSpeed.text = data.stopSpeed.ToString();
            MaxSpeed.text = data.maxSpeed.ToString();
            SpeedBumps.text = data.speedBumps.ToString();
            JumpForce.text = data.jumpForce.ToString();
        }
    }
}