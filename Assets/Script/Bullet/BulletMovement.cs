using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerfectRoot.Bullets
{
    public class BulletMovement : MonoBehaviour
    {
        private Rigidbody2D rb;

        [Header("Reference")]
        private Bullet bullet;

        private void Awake()
        {
            bullet = GetComponent<Bullet>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            //rb.velocity += new Vector2(0, bullet.BulletData.speed * Time.deltaTime);
            rb.AddForce(new Vector2(0, bullet.BulletData.speed));
        }
    }
}