using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using WolfFighter.Base;

namespace WolfFighter.Test
{
    public class TestLivingObject : LivingObject
    {
        protected override void Start()
        {
            base.Start();
            this.Speed = 0.1f;
            this.Hp = 100;
        }

    }

}
