using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using WolfFighter.FX;

namespace WolfFighter.Level1
{
    public class EnemyBlackBall : Enemy
    {
        protected override void Start()
        {
            base.Start();
            this.Hp = 5;
        }

        public override void Die()
        {
            this.transform.GetComponentInParent<BlackBall>().DestroyBlackBall();
        }
    }

}
