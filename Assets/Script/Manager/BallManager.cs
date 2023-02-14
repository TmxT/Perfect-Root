using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Misc;
using PerfectRoot.SO;
using PerfectRoot.Balls;
using PerfectRoot.Event;

namespace PerfectRoot
{
    public class BallManager : MonoBehaviour, IEventGame
    {
        public static BallManager Instance { get; private set; }

        private List<Ball> listActiveBall = new List<Ball>();

        [SerializeField] Transform[] arrTransInitSpawn;
        [SerializeField] SOBall[] arrInitBall;

        [Space]
        [SerializeField] PoolerContainerBall poolerBall;

        [Space]
        [SerializeField] LayerMask playerArea;

        [SerializeField] float delayPlayerArea;

        public LayerMask PlayerArea => playerArea;

        public float DelayPlayerArea => delayPlayerArea;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            for (int i = 0; i < arrTransInitSpawn.Length; i++)
                Pop(arrTransInitSpawn[i].position, arrInitBall[i], 0, 1);
        }

        public void Pop(Vector2 _pos, SOBall _ball, int _level, int _root)
        {
            for (int i = 0; i < _root; i++)
                poolerBall.Pop().Setup(_pos, _ball, _level);
        }

        public void AddBall(Ball _ball)
        {
            if (!listActiveBall.Contains(_ball))
                listActiveBall.Add(_ball);
        }

        public void RemoveBall(Ball _ball)
        {
            if (listActiveBall.Contains(_ball))
                listActiveBall.Remove(_ball);

            if (_ball.BallData.arrValue.Length - 1 == _ball.Level && listActiveBall.Count == 0)
                GameManager.Instance.Win();
        }

        public void OnEventGame(EnumGame _game)
        {
            /*if(_game == EnumGame.Play)
                Init();*/
        }

        private void OnEnable()
        {
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if(!gameObject.scene.isLoaded) return;

            EventGame.Instance.RemoveListener(OnEventGame);
        }
    }
}