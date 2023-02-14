using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Event
{
    public class EventScore : MonoBehaviour
    {
        public static EventScore Instance;

        private event Action OnScore;

        private void Awake()
        {
            Instance = this;
        }

        public void Invoke()
        {
            OnScore?.Invoke();
        }

        public void AddListener(Action _listener)
        {
            OnScore += _listener;
        }

        public void RemoveListener(Action _listener)
        {
            OnScore -= _listener;
        }
    }

    public interface IEventScore
    {
        public void OnEventScore();
    }
}