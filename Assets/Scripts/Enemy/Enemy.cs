using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Events;

namespace WolfFighter.Base
{
    public class Enemy : LivingObject
    {
        protected override void Start()
        {
            base.Start();
            this.SelfType = LivingObjectType.Enemy;
        }
    }
}
