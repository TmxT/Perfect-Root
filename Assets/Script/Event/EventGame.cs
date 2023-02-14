using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Event
{
    public class EventGame : MonoBehaviour
    {
        public static EventGame Instance;

        private event Action<EnumGame> OnGame;

        public EnumGame CurrentGame { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public void Invoke(EnumGame _game)
        {
            Debug.Log(_game);
            CurrentGame = _game;
            OnGame?.Invoke(_game);
        }

        public void AddListener(Action<EnumGame> _listener)
        {
            OnGame += _listener;
        }

        public void RemoveListener(Action<EnumGame> _listener)
        {
            OnGame -= _listener;
        }
    }

    public interface IEventGame
    {
        public void OnEventGame(EnumGame _game);
    }
}