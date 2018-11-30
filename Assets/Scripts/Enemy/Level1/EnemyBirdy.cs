using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using WolfFighter.Player;
namespace WolfFighter.Level1
{
    public class EnemyBirdy : Enemy
    {
        public GameObject deadBullet;
        const float ViewDistance = 1.5f;
        Vector2 dir;
        protected override void Start()
        {
            base.Start();
            this.Hp = 5;
            this.Speed = 1.5f;
            this.OnDie += () =>
            {
                Vector2 delta = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
                float angle = Mathf.Atan2(delta.y, delta.x);
                GameObject db = Instantiate(deadBullet);
                db.transform.position = this.transform.position;
            };
            dir = Vector2.down;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Player.Player._Instance != null)
            {
                float distance = Vector2.Distance(Player.Player._Instance.transform.position, this.transform.position);
                if (distance <= ViewDistance)
                {
                    dir = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
                }
            }

            this.transform.Translate(dir * this.Speed * Time.deltaTime);
        }
    }
}
