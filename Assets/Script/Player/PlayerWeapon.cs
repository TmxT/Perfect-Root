using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.SO;
using PerfectRoot.Misc;

namespace PerfectRoot.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] SOWeapon weapon;

        [Space]
        [SerializeField] PoolerContainer poolerBulletA;
        [SerializeField] PoolerContainer poolerBulletB;

        [Space]
        [SerializeField] Transform transBulletPos;

        private float delay;

        [Header("Reference")]
        private PlayerArea playerArea;
        private PlayerSfx playerSfx;

        private void Awake()
        {
            playerArea = GetComponent<PlayerArea>();
            playerSfx = GetComponent<PlayerSfx>();
        }

        private void Update()
        {
            if(delay > 0)
                delay -= Time.deltaTime;
        }

        public void RequestShoot()
        {
            Shoot();
        }

        private void Shoot()
        {
            if (delay > 0)
                return;

            playerSfx.Play(weapon.sfxShoot);

            PoolerContainer tempPooler = null;

            if(playerArea.BulletArea == EnumBulletBallType.A)
                tempPooler = poolerBulletA;
            else if(playerArea.BulletArea == EnumBulletBallType.B)
                tempPooler = poolerBulletB;

            if (!tempPooler)
                return;

            tempPooler.Pop().transform.position = transBulletPos.position;

            delay = weapon.delay;
        }
    }
}