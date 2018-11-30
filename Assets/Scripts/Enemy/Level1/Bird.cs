using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Level1
{
    public class Bird : Enemy
    {
        protected override void Start()
        {
            base.Start();
            this.Hp = 10;
        }
    }

}
