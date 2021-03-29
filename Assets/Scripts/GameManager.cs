using DonkeyDrums.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DonkeyDrums.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] UIManager UIManager = null;
        private static GameManager _instance;

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
    }
}