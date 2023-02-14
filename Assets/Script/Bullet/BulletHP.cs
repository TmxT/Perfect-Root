using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Misc;

namespace PerfectRoot.Bullets
{
    public class BulletHP : MonoBehaviour
    {
        [Header("Reference")]
        private Bullet bullet;
        private BulletSfx bulletSfx;

        private void Awake()
        {
            bullet = GetComponent<Bullet>();
            bulletSfx = GetComponent<BulletSfx>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(LayerComparer.Compare(bullet.BulletData.target, collision.gameObject.layer))
                bulletSfx.Play(bullet.BulletData.sfxFalseHit);

            gameObject.SetActive(false);
        }
    }
}