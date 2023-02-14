using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.SO;
using PerfectRoot.Player;

namespace PerfectRoot.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] SOBullet bullet;

        public SOBullet BulletData => bullet;
    }
}