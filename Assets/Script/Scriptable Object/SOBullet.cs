using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.SO
{
    [CreateAssetMenu(fileName = "Bullet ", menuName = "Weapon/Bullet")]
    public class SOBullet : ScriptableObject
    {
        public EnumBulletBallType type;

        [Space]
        public LayerMask target;
        public LayerMask targetFalse;

        [Header("SFX")]
        public AudioClip sfxFalseHit;

        [Space]
        public float speed;
    }
}