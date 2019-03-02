using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Level1
{

    public class EnemyBee : Enemy
    {
        public GameObject deadBullet;
        public GameObject shootBullet;
        Vector2 dir;
        protected override void Start()
        {
            base.Start();
            this.Hp = 2;
            this.OnDie += () =>
            {                
                GameObject db = Instantiate(deadBullet);
                db.transform.position = this.transform.position;

            };
            dir = Vector2.down;
        }

        private void FixedUpdate()
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        IEnumerator ShootAsyc()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(1f, 3f));
                ShootToPlayer();
            }
        }

        void ShootToPlayer()
        {
            if(Player.Player._Instance != null)
            {
                Vector2 delta = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
                float angle = Mathf.Atan2(delta.y, delta.x);
                GameObject db = Instantiate(deadBullet);
                db.transform.position = this.transform.position;
                BulletBase bullet = db.GetComponent<BulletBase>();
                bullet.MoveSpeed = 2;
                bullet.MoveDirection = delta;
                bullet.BulletDamage = 15;
            }
            else
            {
                return;
            }
        }
    }
}
