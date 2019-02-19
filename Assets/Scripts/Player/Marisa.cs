using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using UniRx;
using UniRx.Triggers;
using WolfFighter.Utility;

namespace WolfFighter.Player
{
    public class Marisa : LivingObject, IAttack
    {
        
        private GameObject bulletObj;
        private GameObject DeadFX;

        public Vector2 RestrictedAreaMin;
        public Vector2 RestrictedAreaMax;

        public Rect RestrictedArea
        {
            get
            {
                float width = RestrictedAreaMax.x - RestrictedAreaMin.x;
                float height = RestrictedAreaMax.y - RestrictedAreaMin.y;
                Rect rect = new Rect(RestrictedAreaMin.x, RestrictedAreaMin.y, width, height);
                return rect;
            }
        }

        public BulletBase BulletType
        {
            get
            {
                return bulletObj.GetComponent<BulletBase>();
            }

            set
            {
                
            }
        }
        
        private float shotCoolDown;
        private SpriteRenderer spriteRender;
        Animator aniCon;
        /// <summary>
        /// 受到伤害的时候置为True，冷却完毕后置为False
        /// 在True状态时不会再收到伤害
        /// </summary>
        private bool isHurtCoolDown = false;

        protected override void Awake()
        {
            base.Awake();
            spriteRender = this.GetComponentInChildren<SpriteRenderer>();
        }
        protected override void Start()
        {
            base.Start();
            aniCon = this.GetComponentInChildren<Animator>();
            this.Speed = 0.1f;
            this.SetWeapon();
            this.DeadFX = ResourceManager._Instance.PlayerDeadExplodeFX;
            this.OnDie += PlayerDead;
        }

        public override void Move(Vector2 deltaPos)
        {
            base.Move(deltaPos);
            if (this.aniCon != null)
                aniCon.SetFloat("horizontal", deltaPos.x);
        }

        public void Ability()
        {
            throw new System.NotImplementedException();
        }

        public void Fire()
        {
            if(shotCoolDown>0)
            {
                shotCoolDown--;
                return;
            }
            else
            {
                shotCoolDown = BulletType.AttackRate;
                GameObject bullet = Instantiate(this.bulletObj);
                bullet.transform.position = this.transform.position;
            }
        }

        public void SetWeapon()
        {
            int playerWeaponLevel = GameManager._Instance.PlayerWeaponLevel;
            if(playerWeaponLevel>= ResourceManager._Instance.PlayerBulletPrefabs.Length)
            {
                bulletObj = ResourceManager._Instance.PlayerBulletPrefabs[ResourceManager._Instance.PlayerBulletPrefabs.Length-1];
            }
            else
            {
                bulletObj = ResourceManager._Instance.PlayerBulletPrefabs[playerWeaponLevel];
            }            
            shotCoolDown = BulletType.AttackRate;            
        }
        
        public void UpgradeWeapon()
        {
            GameManager._Instance.PlayerWeaponLevel++;
            SetWeapon();
        }

        public bool isInRestrictedArea(Vector2 pos)
        {
            return RestrictedArea.Contains(pos);
        }

        [ContextMenu("Set Restricted Area Min")]
        public void SetAreaMin()
        {
            this.RestrictedAreaMin = new Vector2(this.transform.position.x, this.transform.position.y);
        }

        [ContextMenu("Set Restricted Area Max")]
        public void SetAreaMax()
        {
            this.RestrictedAreaMax = new Vector2(this.transform.position.x, this.transform.position.y);
        }

        void PlayerDead()
        {
            Instantiate(DeadFX).transform.position = this.transform.position;
            Destroy(this.gameObject);
        }

        public override void Hurt(int damage)
        {
            if (isHurtCoolDown)
                return;

            HurtCoolDown = StartCoroutine(HurtCoolDownProcess());
            Hp -= damage;
            isHurtCoolDown = true;
            if (OnHurt != null)
                OnHurt();

            if (Hp <= 0)
            {
                Die();
            }
        }

        Coroutine HurtCoolDown;
        IEnumerator HurtCoolDownProcess()
        {
            //在此打开受伤特效
            HurtFX = StartCoroutine(HurtFxProcess());
            yield return new WaitForSeconds(GameManager._Instance.HurtCoolDownTime);
            isHurtCoolDown = false;
            StopCoroutine(HurtFX);
            spriteRender.color = new Color(1, 1, 1, 1);
            //在此关闭受伤特效
        }

        Coroutine HurtFX;
        IEnumerator HurtFxProcess()
        {
            spriteRender.color = new Color(1, 1, 1, 1);
            while (true)
            {
                spriteRender.color = new Color(1, 1, 1, 0.25f);
                yield return new WaitForSeconds(0.1f);
                spriteRender.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerKiller killer = collision.GetComponent<PlayerKiller>();
            if (killer != null)
            {
                Die();
            }
        }

        private void Update()
        {
            
        }
    }

}
