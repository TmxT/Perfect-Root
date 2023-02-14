using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Event;

namespace PerfectRoot.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Reference")]
        private PlayerMovement playerMovement;
        private PlayerWeapon playerWeapon;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            playerWeapon = GetComponent<PlayerWeapon>();
        }

        private void FixedUpdate()
        {
            if (EventGame.Instance.CurrentGame == EnumGame.Pause || EventGame.Instance.CurrentGame == EnumGame.GameOver || EventGame.Instance.CurrentGame == EnumGame.None)
                return;

            if(Input.GetKey(KeyCode.LeftArrow))
                playerMovement.MoveLeft();
            else if(Input.GetKey(KeyCode.RightArrow)) 
                playerMovement.MoveRight();
            else
                playerMovement.MoveStop();

            if(Input.GetKey(KeyCode.Space))
                playerWeapon.RequestShoot();
        }
    }
}