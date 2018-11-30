using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UniRx;
namespace WolfFighter.Base
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class LivingObject : MonoBehaviour
    {
        private int HealthPoint;
        private int EnergyPoint;
        private float MoveSpeed;
        protected Rigidbody2D rigid2D;

        public int Hp
        {
            get
            {
                return HealthPoint;
            }

            set
            {
                HealthPoint = value;
            }
        }

        public int MP
        {
            get
            {
                return EnergyPoint;
            }
            set
            {
                EnergyPoint = value;
            }
        }

        public float Speed
        {
            get
            {
                return MoveSpeed;
            }

            set
            {
                MoveSpeed = value;
            }
        }


        public UnityAction OnHurt;
        public UnityAction OnDie;

        public LivingObjectType SelfType;

        public GameObject DestroyFX;

        protected virtual void Awake()
        {
            rigid2D = this.GetComponent<Rigidbody2D>();
            
        }

        protected virtual void Start()
        {
            
        }

        /// <summary>
        /// 移动到某个点
        /// </summary>
        /// <param name="destnation">目标点坐标</param>
        public virtual void MoveTo(Vector2 destnation,float duration,Ease ease = Ease.Linear)
        {
            Vector3 pos = new Vector3(destnation.x, destnation.y, this.transform.position.z);
            rigid2D.DOMove(pos, duration).SetEase(ease);
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="deltaPos">移动变量</param>
        public virtual void Move(Vector2 deltaPos)
        {
            Vector2 next = this.transform.position + new Vector3(deltaPos.x, deltaPos.y, 0) * Speed;
            rigid2D.MovePosition(next);    
        }
        
        /// <summary>
        /// 受到攻击
        /// </summary>
        /// <param name="damage">伤害值</param>
        public virtual void Hurt(int damage)
        {
                Hp -= damage;

                if (OnHurt != null)
                    OnHurt();

                if (Hp <= 0)
                {
                    Die();
                }
        }

        /// <summary>
        /// 死亡
        /// </summary>
        public virtual void Die()
        {            
            if (OnDie != null)
            {
                OnDie();
            }

            if (DestroyFX != null)
                Instantiate(DestroyFX).transform.position = this.transform.position;

            Destroy(this.gameObject);
        }
    }       

}
