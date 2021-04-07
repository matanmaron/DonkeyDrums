using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Jump = null;
    [SerializeField] AudioSource Score = null;
    [SerializeField] AudioSource Win = null;
    [SerializeField] AudioSource Music = null;

    public void PlayJump()
    {
        Jump.Play();
    }
    public void PlayScore()
    {
        Score.Play();
    }
    public void PlayMusic()
    {
        Music.Play();
    }
    public void StopMusic()
    {
        Music.Pause();
    }
    public void PlayWin()
    {
        Win.Play();
    }
}
