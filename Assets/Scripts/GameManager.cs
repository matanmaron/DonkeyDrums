using DonkeyDrums.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DonkeyDrums.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] UIManager UIManager = null;
        private static GameManager _instance;
        private int coins = 0;

        public static GameManager Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        internal void AddCoin()
        {
            coins++;
            UIManager.ShowCoins(coins);
        }

        internal void GameOver()
        {
            SceneManager.LoadScene(0);
        }
    }
}