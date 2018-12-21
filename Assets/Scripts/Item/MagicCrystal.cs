using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Item
{
    public class MagicCrystal : BootyBase
    {
        public int RecoverMp;

        private void OnEnable()
        {
            this.OnTouch += RecoverMP;
        }

        private void OnDisable()
        {
            this.OnTouch -= RecoverMP;
        }

        void RecoverMP()
        {
            Player.Player._Instance.RecoverMp(RecoverMp);
        }
    }

}
