using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Item
{
    public class HpItem : BootyBase
    {
        public int RecoverHp;
        protected override void Start()
        {
            base.Start();
            this.OnTouch += Heal;
        }

        void Heal()
        {
            Player.Player._Instance.RecoverHp(RecoverHp);
        }
    }

}
