using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Balls
{
    public class BallSfx : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponentInChildren<AudioSource>();
        }

        public void PlaySfx(AudioClip _sfx)
        {
            audioSource.clip = _sfx;
            audioSource.Play();
        }
    }
}