using PerfectRoot.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot
{
    public class TimeManager : MonoBehaviour
    {
        public static TimeManager Instance { get; private set; }

        [SerializeField] private float time;

        public float CurrentTime => time;

        public int Min => (int)time / 60;
        public int Sec => (int)time % 60;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (EventGame.Instance.CurrentGame == EnumGame.Pause || EventGame.Instance.CurrentGame == EnumGame.GameOver || EventGame.Instance.CurrentGame == EnumGame.None)
                return;

            time += Time.deltaTime;
        }

        public int ConvertToSec(float _time)
        {
            return (int)_time % 60;
        }

        public int ConvertToMin(float _time)
        {
            return (int)_time / 60;
        }
    }
}