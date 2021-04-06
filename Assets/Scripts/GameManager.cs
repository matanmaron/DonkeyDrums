using DonkeyDrums.Data;
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
        public GameData data;
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

        private void Start()
        {
            data = Settings.ImportSettings();
            Debug.Log(data);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                UIManager.ToggleSettings();
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