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
            this.Hp = 5;
            this.Speed = 1.5f;
            this.DestroyFX = Resources.Load<GameObject>("Prefab/FX/ExplodeFX1");
        }

        private void Update()
        {
            this.Move(Vector2.down * Time.deltaTime);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Bound"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}

