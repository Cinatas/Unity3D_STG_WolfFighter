using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
namespace WolfFighter.Level1
{
    /// <summary>
    /// 蝙蝠Lv1，每一秒移动一次位置，并向主角发射一枚子弹
    /// </summary>
    public class EnemyBat : Enemy
    {
        public Vector3[] poses;
        public GameObject Bullet;
        protected override void Start()
        {
            base.Start();
            this.Hp = 50;
            this.transform.DOMoveY(2, 2).OnComplete(()=>
            {
                StartCoroutine(Attack());
            });
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator Attack()
        {
            foreach(var i in poses)
            {
                this.MoveTo(i, 0.75f);
                yield return new WaitForSeconds(0.75f);

                if (Player.Player._Instance != null)
                {
                    //发射子弹
                    GameObject bulletObj = Instantiate(Bullet);
                    bulletObj.transform.position = this.transform.position;
                    Vector2 dir = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
                    BulletBase bullet = bulletObj.GetComponent<BulletBase>();
                    bullet.MoveSpeed = 5;
                    bullet.MoveDirection = dir;
                }

                yield return new WaitForSeconds(0.5f);
            }
            Destroy(this.gameObject, 3);
        }
    }

}
