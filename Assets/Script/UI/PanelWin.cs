using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.UI
{
    public class PanelWin : MonoBehaviour, IEventGame
    {
        [SerializeField] GameObject objPanel;

        [Space]
        [SerializeField] TMP_Text textYourTime;
        [SerializeField] TMP_Text textBestTime;

        [Space]
        [SerializeField] AudioClip sfxClick;

        public void Open()
        {
            objPanel.SetActive(true);

            Refresh();
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

        private void Refresh()
        {
            textYourTime.text = string.Format($"({TimeManager.Instance.Min.ToString("00")} : {TimeManager.Instance.Sec.ToString("00")})");
            textBestTime.text = string.Format($"({TimeManager.Instance.ConvertToMin(GameManager.Instance.BestTime).ToString("00")} : {TimeManager.Instance.ConvertToSec(GameManager.Instance.BestTime).ToString("00")})");
        }

        public void OnEventGame(EnumGame _game)
        {
            if(_game == EnumGame.Win)
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