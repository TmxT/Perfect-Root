using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using PerfectRoot.Event;

namespace PerfectRoot
{
    public class GameManager : MonoBehaviour, IEventScore, IEventGame
    {
        public static GameManager Instance;

        [SerializeField] AudioSource audioSourceSfx;
        [SerializeField] AudioSource audioSourceBgm;

        [Space]
        [SerializeField] AudioClip sfxMainMenu;
        [SerializeField] AudioClip sfxGameplay;
        [SerializeField] AudioClip sfxWin;
        [SerializeField] AudioClip sfxGameOver;
        [SerializeField] AudioClip sfxClick;

        private float bestTime = 0;

        private int score;
        
        public float BestTime => bestTime;

        public int Score => score;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayBgm(sfxMainMenu);

            bestTime = PlayerPrefs.GetFloat("Best Time");
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Return) && (EventGame.Instance.CurrentGame == EnumGame.Win || EventGame.Instance.CurrentGame == EnumGame.GameOver))
            {
                PlaySfx(sfxClick);
                RestartGame();
            }
        }

        private void AddScore()
        {
            score += 2;
        }

        public void Win()
        {
            Debug.Log("WIN");

            audioSourceBgm.Stop();

            PlaySfx(sfxWin);

            if(TimeManager.Instance.CurrentTime < bestTime || bestTime == 0)
            {
                bestTime = TimeManager.Instance.CurrentTime;
                PlayerPrefs.SetFloat("Best Time", bestTime);
            }

            EventGame.Instance.Invoke(EnumGame.Win);
        }

        public void GameOver()
        {
            Debug.Log("GAME OVER");

            audioSourceBgm.Stop();
            PlaySfx(sfxGameOver);

            EventGame.Instance.Invoke(EnumGame.GameOver);
        }

        public void PlaySfx(AudioClip _sfx)
        {
            audioSourceSfx.clip = _sfx;
            audioSourceSfx.Play();
        }

        private void PlayBgm(AudioClip _bgm)
        {
            audioSourceBgm.clip = _bgm;
            audioSourceBgm.Play();
        }

        public void RestartGame()
        {
            Invoke("Restart", 1f);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }

        public void OnEventScore()
        {
            AddScore();
        }

        public void OnEventGame(EnumGame _game)
        {
            if (_game == EnumGame.Play)
                PlayBgm(sfxGameplay);
        }

        private void OnEnable()
        {
            EventScore.Instance.AddListener(OnEventScore);
            EventGame.Instance.AddListener(OnEventGame);
        }

        private void OnDisable()
        {
            if (!gameObject.scene.isLoaded) return;

            EventScore.Instance.RemoveListener(OnEventScore);
            EventGame.Instance.RemoveListener(OnEventGame);
        }
    }
}