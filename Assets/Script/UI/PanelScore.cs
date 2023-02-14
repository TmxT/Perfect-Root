using PerfectRoot.Event;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PerfectRoot.UI
{
    public class PanelScore : MonoBehaviour
    {
        [SerializeField] TMP_Text textScore;
        [SerializeField] TMP_Text textTime;

        [Header("Reference")]
        private GameManager gameManager;
        private TimeManager timeManager;

        private void Awake()
        {
            gameManager = GameManager.Instance;
            timeManager = TimeManager.Instance;
        }

        private void Update()
        {
            if (EventGame.Instance.CurrentGame == EnumGame.Pause || EventGame.Instance.CurrentGame == EnumGame.GameOver || EventGame.Instance.CurrentGame == EnumGame.None)
                return;

            textTime.text = string.Format($"{timeManager.Min.ToString("00")} : {timeManager.Sec.ToString("00")}");
        }
    }
}