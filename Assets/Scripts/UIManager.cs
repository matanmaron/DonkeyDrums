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

        internal void ShowCoins(int coins)
        {
            CoinText.text = coins.ToString();
        }
    }
}