using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Player
{
    public class PlayerArea : MonoBehaviour
    {
        public EnumBulletBallType BulletArea
        {
            get
            {
                if (transform.position.x > 0)
                    return EnumBulletBallType.B;
                else
                    return EnumBulletBallType.A;
            }
        }
    }
}