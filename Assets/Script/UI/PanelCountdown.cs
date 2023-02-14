using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using PerfectRoot.Event;

namespace PerfectRoot.UI
{
    public class PanelCountdown : MonoBehaviour, IEventGame
    {
        [SerializeField] GameObject objPanel;

        [Space]
        [SerializeField] TMP_Text textCountdown;

        [Space]
        [SerializeField] float countdown = 3;
        private float currentCountdown;

        public void Open()
        {
            objPanel.SetActive(true);

            StartCoroutine(CoroutineCountdown());
        }

        public void Close()
        {
            objPanel.SetActive(false);
        }

        private IEnumerator CoroutineCountdown()
        {
            currentCountdown = countdown;

            EventGame.Instance.Invoke(EnumGame.Pause);

            while (currentCountdown > 0)
            {
                currentCountdown -= Time.deltaTime;
                textCountdown.text = ((int)currentCountdown).ToString();
                yield return null;
            }

            EventGame.Instance.Invoke(EnumGame.Play);

            Close();
        }

        public void OnEventGame(EnumGame _game)
        {
            /*if (_game == EnumGame.Play)
                Open();*/
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