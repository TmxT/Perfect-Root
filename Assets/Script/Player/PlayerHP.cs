using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.Player
{
    public class PlayerHP : MonoBehaviour, IEventScore
    {
        public static PlayerHP Instance { get; private set; }

        [SerializeField] AudioClip sfxHit;
        public AudioClip sfxCollect;

        private bool invicible;

        [Header("Reference")]
        private PlayerSfx playerSfx;

        private void Awake()
        {
            Instance = this;

            playerSfx = GetComponent<PlayerSfx>();
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.I))
                invicible = !invicible;
        }

        public void Collected()
        {
            playerSfx.Play(sfxCollect);
        }

        public void Damaged()
        {
            if (invicible)
                return;

            playerSfx.Play(sfxHit);
            GameManager.Instance.GameOver();
        }

        public void OnEventScore()
        {
            Collected();
        }

        private void OnEnable()
        {
            EventScore.Instance.AddListener(OnEventScore);
        }

        private void OnDisable()
        {
            if (!gameObject.scene.isLoaded) return;

            EventScore.Instance.RemoveListener(OnEventScore);
        }
    }
}