using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonkeyDrums.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] float stopSpeed = 0.01f;
        [SerializeField] float maxSpeed = 2;
        [SerializeField] float speedBumps = 0.1f;
        private float speed = 0f;
        private bool keyAlternate;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && keyAlternate == false)
            {
                speed += speedBumps;
                keyAlternate = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && keyAlternate == true)
            {
                speed += speedBumps;
                keyAlternate = false;
            }
            else
            {
                speed -= stopSpeed;
            }
            if (speed < 0)
            {
                speed = 0;
            }
            if (speed > maxSpeed)
            {
                speed = maxSpeed;
            }
            if (speed != 0)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                Debug.Log($"speed - {speed}");
            }
        }
    }
}