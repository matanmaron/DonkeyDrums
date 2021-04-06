using DonkeyDrums.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DonkeyDrums.Core
{
    public class Player : MonoBehaviour
    {
        private Animator animator = null;
        private Rigidbody2D rbody = null;
        private float speed = 0f;
        private bool keyAlternate;
        private bool isWalking = false;
        private bool isGrounded = false;
        GameData data => GameManager.Instance.data;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (transform.position.y < -10)
            {
                GameManager.Instance.GameOver();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && keyAlternate == false)
            {
                speed += data.speedBumps;
                keyAlternate = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && keyAlternate == true)
            {
                speed += data.speedBumps;
                keyAlternate = false;
            }
            else
            {
                speed -= data.stopSpeed;
            }
            if (speed < 0)
            {
                speed = 0;
            }
            if (speed > data.maxSpeed)
            {
                speed = data.maxSpeed;
            }
            if (speed != 0)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                //Debug.Log($"speed - {speed}");
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                rbody.AddForce(new Vector2(0, data.jumpForce), ForceMode2D.Impulse);
            }
            SetAnim();
        }

        private void SetAnim()
        {
            if (speed != 0 && !isWalking)
            {
                //Debug.Log("Animator - Walking");
                isWalking = true;
                animator.SetBool("Walking", true);
            }
            else if (speed == 0 && isWalking)
            {
                //Debug.Log("Animator - Idle");
                isWalking = false;
                animator.SetBool("Walking", false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!isGrounded && collision.gameObject.tag == "Ground")
            {
                Debug.Log("Hit Ground");
                isGrounded = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Coin")
            {
                Debug.Log("Hit Coin");
                GameManager.Instance.AddCoin();
                Destroy(collision.gameObject);
            }
        }
    }
}