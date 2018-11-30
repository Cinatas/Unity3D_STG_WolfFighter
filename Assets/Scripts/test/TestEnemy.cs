using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Test
{
    public class TestEnemy : LivingObject
    {
        protected override void Start()
        {
            base.Start();
            this.Hp = 1;
            this.OnDie += () => { Destroy(this.gameObject); };

        }
    }

}
