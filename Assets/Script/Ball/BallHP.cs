using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Misc;
using PerfectRoot.Player;
using PerfectRoot.Event;

namespace PerfectRoot.Balls
{
    public class BallHP : MonoBehaviour
    {
        [Header("Reference")]
        private Ball ball;
        private BallSfx ballSfx;

        private void Awake()
        {
            ball = GetComponent<Ball>();
            ballSfx = GetComponent<BallSfx>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag(EnumTag.BorderDown.ToString()))
                ballSfx.PlaySfx(ball.BallData.arrSfxBounce[ball.Level]);

            if(LayerComparer.Compare(ball.BallData.targetDie, collision.gameObject.layer))
                Die();
            else if(LayerComparer.Compare(ball.BallData.targetCollector, collision.gameObject.layer))
                Collected();
        }

        private void Die()
        {
            if (ball.Level >= ball.BallData.arrValue.Length - 1)
                return;

            ballSfx.PlaySfx(ball.BallData.sfxDie);

            BallManager.Instance.Pop((Vector2)transform.position + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)), ball.BallData, ball.Level + 1, ball.BallData.root);

            gameObject.SetActive(false);
        }

        private void Collected()
        {
            if (ball.Level < ball.BallData.arrValue.Length - 1)
            {
                PlayerHP.Instance.Damaged();
                return;
            }

            EventScore.Instance.Invoke();

            gameObject.SetActive(false);
        }
    }
}