using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Player;

namespace WolfFighter.Level1 {

    public class DeadBodyBullet : EnemyBullet
    {
        private void FixedUpdate()
        {

        }

        protected override void BulletMoving()
        {
            this.transform.Translate(Vector2.down * Time.deltaTime * this.MoveSpeed, Space.Self);
        }
    }
}
