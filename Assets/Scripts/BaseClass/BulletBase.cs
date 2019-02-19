using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
namespace WolfFighter.Base
{
    /// <summary>
    /// 子弹类型，包含单发子弹的伤害值以及攻击速度
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BulletBase : MonoBehaviour
    {
        protected Rigidbody2D rigid2D;
        /// <summary>
        /// 子弹的生效目标
        /// </summary>
        public LivingObjectType ActiveType;
        public float MoveSpeed;
        public Vector2 MoveDirection;
        public GameObject hitFX;
        protected virtual void Awake()
        {
            rigid2D = this.GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            this.FixedUpdateAsObservable().Subscribe(_=>BulletMoving());
        }

        /// <summary>
        /// 单发子弹的伤害
        /// </summary>
        public int BulletDamage;
        /// <summary>
        /// 攻击速度,每多少帧发射一次
        /// </summary>
        public float AttackRate;

        protected virtual void Hit(LivingObject lo)
        {
            lo.Hurt(this.BulletDamage);
            //还需要生成hit特效
            if (hitFX != null)
                Instantiate(hitFX).transform.position = this.transform.position;
            //并销毁自身
            Destroy(this.gameObject);
        }

        protected virtual void BulletMoving()
        {
            Vector2 nextPos = (Vector2)this.transform.position + MoveDirection * MoveSpeed * Time.deltaTime;
            
            this.rigid2D.MovePosition(nextPos);

            float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
            this.transform.localRotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        }
        /// <summary>
        /// 触碰到边界后销毁自身
        /// </summary>
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Bound"))
            {
                Destroy(this.gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            LivingObject lo = collision.GetComponent<LivingObject>();
            if (lo == null)
                return;
            if (lo.SelfType == LivingObjectType.Null)
                return;

            if(lo.SelfType == ActiveType)
            {
                Hit(lo);
            }
        }
    }
}
