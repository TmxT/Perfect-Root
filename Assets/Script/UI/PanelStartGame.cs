using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.UI
{
    public class PanelStartGame : MonoBehaviour
    {
        [SerializeField] GameObject objPanel;

        [Space]
        [SerializeField] AudioClip sfxClick;

        [Header("Reference")]
        private PanelCountdown panelCountdown;

        private void Awake()
        {
            panelCountdown = GetComponent<PanelCountdown>();
        }

        private void Update()
        {
            if(Input.anyKey && objPanel.activeSelf)
            {
                GameManager.Instance.PlaySfx(sfxClick);
                Close();
            }
        }

        public void Open()
        {
            objPanel.SetActive(true);
        }

        public void Close()
        {
            panelCountdown.Open();

            objPanel.SetActive(false);
        }
    }
}