using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PerfectRoot.Bullets;

namespace PerfectRoot.SO
{
    [CreateAssetMenu(fileName = "Weapon ", menuName = "Weapon/Weapon")]
    public class SOWeapon : ScriptableObject
    {
        [Header("SFX")]
        public AudioClip sfxShoot;

        [Space]
        public float delay;
    }
}