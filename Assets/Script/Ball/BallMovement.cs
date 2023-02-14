using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Misc;
using PerfectRoot.Event;

namespace PerfectRoot.Balls
{
    public class BallMovement : MonoBehaviour, IEventGame
    {
        private Rigidbody2D rb;

        private Vector2 lastVelocity;

        private float delay;

        [Header("Reference")]
        private Ball ball;
        private BallManager ballManager;

        private void Awake()
        {
            ball = GetComponent<Ball>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            ballManager = BallManager.Instance;

            delay = ballManager.DelayPlayerArea;
        }

        private void FixedUpdate()
        {
            lastVelocity = rb.velocity;
        }

        public void RandomForce(float _multiply = 1)
        {
            rb.velocity = new Vector2(Random.Range(-2 * _multiply, 2 * _multiply), Random.Range(-2 * _multiply, 2 * _multiply));
        }

        public void Freeze(bool _freeze)
        {
            rb.constraints = _freeze ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.FreezeRotation;
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.Play)
            {
                Freeze(false);
                RandomForce();
            }
            else if (_game == EnumGame.Pause || _game == EnumGame.GameOver)
                Freeze(true);
            else if (_game == EnumGame.Resume)
                Freeze(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (LayerComparer.Compare(ballManager.PlayerArea, collision.gameObject.layer))
            {
                delay -= Time.deltaTime;

                if(delay <= 0)
                {
                    delay = ballManager.DelayPlayerArea;
                    RandomForce(10);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            delay = ballManager.DelayPlayerArea;
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