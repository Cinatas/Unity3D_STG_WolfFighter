using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
using WolfFighter.Utility;

namespace WolfFighter.Level1
{
    public class Angel4 : Enemy
    {
        public GameObject bulletPrefab;
        bool isEnable = false;
        float timer = 0;
        const float cdStandard = 0.5f;
        float cd;
        SpriteRenderer sp;
        protected override void Awake()
        {
            base.Awake();
            this.Hp = 30;
            sp = this.GetComponent<SpriteRenderer>();
        }

        protected override void Start()
        {
            base.Start();
            this.MoveTo(new Vector2(0, 2), 3);
            this.transform.DOMoveY(2, 3).OnComplete(()=>
            {
                isEnable = true;
            });
            cd = 0;
            StartCoroutine(Exit());
            StartCoroutine(Shoot());
        }

        // Update is called once per frame
        void Update()
        {
            if (!isEnable)
                return;
            timer += Time.deltaTime;
            Vector2 selfPos = new Vector2(2.5f * Mathf.Sin(timer*1.25f), 2 + Mathf.Sin(timer * 1.5f));
            this.transform.position = selfPos;
            if (cd != 0)
                cd -= Time.deltaTime;
        }

        public override void Hurt(int damage)
        {
            if (!isEnable)
                return;
            if (cd > 0)
                return;
            base.Hurt(damage);
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = this.transform.position;
            cd = cdStandard;
        }

        public IEnumerator Exit()
        {
            yield return new WaitForSeconds(20f);
            this.sp.DOFade(0, 1).onComplete+= ()=>
            {
                this.isEnable = false;
                Destroy(this.gameObject);
            };

        }

        IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                int randomIndex = Random.Range(1, 4);
                ExplodeBullets bullet = ExplodeBulletsManager._Instance.GenerateExplodeBullet(randomIndex);
                bullet.transform.position = this.transform.position;
                bullet.selfExtendSpeed = Mathf.Abs(Mathf.Sin(Time.time) + 2f);
                bullet.selfRotateSpeed = 10 * Mathf.Sin(Time.time);
            }
        }
    }

}
