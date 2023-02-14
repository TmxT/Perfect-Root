using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using PerfectRoot.SO;
using PerfectRoot.Misc;
using PerfectRoot.Event;

namespace PerfectRoot.Balls
{
    public class Ball : MonoBehaviour
    {
        private SpriteRenderer sprite;

        private TMP_Text text;

        private SOBall ball;

        private PoolerContainerBall poolerContainer;

        [Header("Reference")]
        private BallMovement ballMovement;

        public SOBall BallData => ball;

        public int Level { get; private set; }

        private void Awake()
        {
            ballMovement = GetComponent<BallMovement>();
            sprite = GetComponent<SpriteRenderer>();
            text = GetComponentInChildren<TMP_Text>();
        }

        public void Setup(Vector2 _pos, SOBall _ball, int _level)
        {
            ball = _ball;
            Level = _level;
            text.text = _ball.arrValue[Level].ToString();
            sprite.color = ball.arrColor[Level];
            float scale = .75f - (float)(.75f * (_level / (float)ball.arrValue.Length));

            transform.position = _pos;
            transform.localScale = new Vector3(scale, scale, scale);

            ballMovement.RandomForce(3);
            BallManager.Instance.AddBall(this);

            Debug.Log(this, this);

            ballMovement.Freeze(EventGame.Instance.CurrentGame == EnumGame.Pause || EventGame.Instance.CurrentGame == EnumGame.GameOver || EventGame.Instance.CurrentGame == EnumGame.None);
        }

        public void SetupContainer(PoolerContainerBall _poolerContainer)
        {
            poolerContainer = _poolerContainer;

            poolerContainer.Remove(this);

            gameObject.SetActive(true);
        }

        private void OnEnable()
        {
            if (poolerContainer)
                poolerContainer.Remove(this);
        }

        private void OnDisable()
        {
            if (poolerContainer)
            {
                poolerContainer.Add(this);

                BallManager.Instance.RemoveBall(this);
            }
        }
    }
}