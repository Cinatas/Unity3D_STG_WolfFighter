using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class Angel4 : Enemy
    {
        public GameObject bulletPrefab;
        bool isEnable = false;
        float timer = 0;
        protected override void Awake()
        {
            base.Awake();
            this.Hp = 30;
        }

        protected override void Start()
        {
            base.Start();
            this.MoveTo(new Vector2(0, 2), 3);
            this.transform.DOMoveY(2, 3).OnComplete(()=>
            {
                isEnable = true;
            });
        }

        // Update is called once per frame
        void Update()
        {
            if (!isEnable)
                return;
            timer += Time.deltaTime;
            Vector2 selfPos = new Vector2(2.5f * Mathf.Sin(timer*1.25f), 2 + Mathf.Sin(timer * 1.5f));
            this.transform.position = selfPos;
        }

        public override void Hurt(int damage)
        {
            if (!isEnable)
                return;
            base.Hurt(damage);
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = this.transform.position;
        }

    }

}
