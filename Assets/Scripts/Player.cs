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
        [SerializeField] float JumpForce = 2f;

        private Animator animator = null;
        private Rigidbody2D rigidbody2D = null;
        private float speed = 0f;
        private bool keyAlternate;
        private bool isWalking = false;
        private bool isGrounded = false;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && keyAlternate == false)
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
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
            SetAnim();
        }

        private void SetAnim()
        {
            if (speed != 0 && !isWalking)
            {
                isWalking = true;
                animator.SetBool("Walking", true);
            }
            else if (speed == 0 && isWalking)
            {
                isWalking = false;
                animator.SetBool("Walking", false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }
    }
}