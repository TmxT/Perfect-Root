using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.SO
{
    [CreateAssetMenu(fileName = "Ball ", menuName = "Ball/Ball")]
    public class SOBall : ScriptableObject
    {
        public int[] arrValue;

        [Space]
        public Color32[] arrColor;

        [Space]
        public EnumBulletBallType type;

        [Space]
        public LayerMask targetDie;
        public LayerMask targetCollector;

        [Header("SFX")]
        public AudioClip[] arrSfxBounce;
        public AudioClip sfxDie;

        [Space]
        public int root;

        [Space]
        public float speed;
    }
}