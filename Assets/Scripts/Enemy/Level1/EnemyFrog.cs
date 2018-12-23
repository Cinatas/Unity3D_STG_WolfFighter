using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Level1
{
    public class EnemyFrog : Enemy
    {

        protected override void Start()
        {
            base.Start();
            this.Hp = 10;
            this.Speed = 1.5f;            
        }

        private void Update()
        {
            this.Move(Vector2.down * Time.deltaTime);
        }
    }
}

