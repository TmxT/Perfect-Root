using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.Player
{
    public class PlayerMovement : MonoBehaviour, IEventGame
    {
        private Rigidbody2D rb;

        [SerializeField] float speed;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void MoveRight()
        {
            Move(1);
        }

        public void MoveLeft()
        {
            Move(-1);
        }

        public void MoveStop()
        {
            Move(0);
        }

        private void Move(float _moveTo)
        {
            rb.velocity = new Vector2(_moveTo * speed * Time.deltaTime, 0);
        }

        public void Freeze(bool _freeze)
        {
            rb.constraints = _freeze ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.Pause || _game == EnumGame.GameOver)
                Freeze(true);
            else if (_game == EnumGame.Resume || _game == EnumGame.Play)
                Freeze(false);
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