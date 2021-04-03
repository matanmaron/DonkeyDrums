using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonkeyDrums.Effects
{
    public class CoinSpin : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(Vector3.up);
        }
    }
}