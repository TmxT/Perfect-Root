using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Bullets
{
    public class BulletSfx : MonoBehaviour
    {
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponentInChildren<AudioSource>();
        }

        public void Play(AudioClip _sfx)
        {
            audioSource.clip = _sfx;
            audioSource.Play();
        }
    }
}