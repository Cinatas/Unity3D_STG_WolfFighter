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
        public int expBouns = 0;
        protected override void Start()
        {
            base.Start();
            this.SelfType = LivingObjectType.Enemy;
        }

        public override void Die()
        {
            if (OnDie != null)
            {
                OnDie();
            }

            if (DestroyFX != null)
                Instantiate(DestroyFX).transform.position = this.transform.position;

            if(Player.Player._Instance != null)
            {
                Player.Player._Instance.GainScoreAndExp(expBouns);
            }

            Destroy(this.gameObject);
        }
    }
}
