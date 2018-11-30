using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class EnemyYellowFlower : Enemy
    {
        public GameObject bulletPrefab;
        Vector2 bulletDir;
        public bool isMirror;
        public EnemyYellowFlower bro;
        public float rate = 0.1f;
        public float speed = 1;
        protected override void Start()
        {
            base.Start();
            this.Hp = 50;

            this.transform.DOLocalMoveY(4, 3.5f).SetEase(Ease.Linear).OnComplete(()=>
            {
                StartCoroutine(LaunchBullet());
            });

            this.OnDie += () =>
            {
                if (bro != null)
                {
                    bro.rate = 0.05f;
                    bro.speed = 2f;
                    bro.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                }  
            };
        }

        private void Update()
        {
            float x = Mathf.Abs(Mathf.Cos(Time.time * speed));
            float y = -1f * Mathf.Abs(Mathf.Sin(Time.time * speed));
            if (isMirror)
                x *= -1;
            bulletDir = new Vector2(1.5f*x, y);
        }

        void LaunchBullet(Vector2 dir)
        {
            var bulletObj = Instantiate(bulletPrefab);
           
            bulletObj.transform.position = this.transform.position;
            BulletBase bullet = bulletObj.GetComponent<BulletBase>();
            bullet.MoveSpeed = 3f;
            bullet.MoveDirection = dir;
        }


        IEnumerator LaunchBullet()
        {
            while (true)
            {
                yield return new WaitForSeconds(rate);
                LaunchBullet(bulletDir);
            }
        }
    }

}
