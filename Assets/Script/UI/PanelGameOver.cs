using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.UI
{
    public class PanelGameOver : MonoBehaviour, IEventGame
    {
        [SerializeField] GameObject objPanel;

        [Space]
        [SerializeField] AudioClip sfxClick;

        public void Open()
        {
            objPanel.SetActive(true);
        }

        public void Close()
        {
            objPanel.SetActive(false);
        }

        public void BtnRestart()
        {
            GameManager.Instance.PlaySfx(sfxClick);
            GameManager.Instance.RestartGame();
        }

        public void OnEventGame(EnumGame _game)
        {
            if(_game == EnumGame.GameOver)
                Open();
        }

        private void OnEnable()
        {
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!gameObject.scene.isLoaded) return;

            EventGame.Instance.RemoveListener(OnEventGame);
        }
    }
}