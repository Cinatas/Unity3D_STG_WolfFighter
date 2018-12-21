using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using WolfFighter.Utility;

namespace WolfFighter.Base
{
    [RequireComponent(typeof(Collider2D))]
    public class BootyBase : MonoBehaviour
    {
        public MoveType moveType;
        protected new Collider2D collider;
        protected Rigidbody2D rigid2D;
        public GameObject TouchFX;

        public float ViewDistance;
        private float distanceToPlayer = float.PositiveInfinity;
        public float moveSpeed;        
        private Vector2 moveDir;
        /// <summary>
        /// 当自身被拾取后触发
        /// </summary>
        protected UnityAction OnTouch;
        protected virtual void Awake()
        {
            collider = this.GetComponent<Collider2D>();
            rigid2D = this.GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        protected virtual void Start()
        {
            collider.isTrigger = true;
            rigid2D.gravityScale = 0;
            rigid2D.mass = 0.5f;
        }

        // Update is called once per frame
        protected virtual void Update()
        {
            if(Player.Player._Instance != null)
            {
                distanceToPlayer = Vector3.Distance(Player.Player._Instance.transform.position,this.transform.position);
            }          
        }

        private void FixedUpdate()
        {
            switch (moveType)
            {
                case MoveType.Null:
                    DontMove();
                    break;
                case MoveType.Random:
                    RandomMove();
                    break;
                case MoveType.Approach:
                    ApproachMove();
                    break;
                case MoveType.Flee:
                    FleeMove();
                    break;
                default:
                    break;

            }            
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            GameObject go = collision.gameObject;
            Player.Player player = go.GetComponent<Player.Player>();
            if (player != null)
            {
                if (OnTouch != null)
                    OnTouch();
                
                Destroy(this.gameObject);
            }

            if(this.moveType == MoveType.Null)
            {
                BulletBase bullet = go.GetComponent<BulletBase>();
                if (bullet != null)
                {                   
                    if (rigid2D.velocity.y < 0)
                        rigid2D.velocity = new Vector2(rigid2D.velocity.x,0);
                    rigid2D.AddForce(Vector2.up * 75);
                    Destroy(bullet.gameObject);
                }
            }
        }

        void DontMove()
        {
            rigid2D.gravityScale = 0.5f;
        }

        void RandomMove()
        {

        }

        void ApproachMove()
        {
            if(distanceToPlayer <= ViewDistance)
            {
                if (Player.Player._Instance != null)
                {
                    Transform player = Player.Player._Instance.transform;
                    moveDir = Vector3.Normalize(player.position - this.transform.position);
                }               
            }
            this.transform.Translate(moveDir * Time.deltaTime * moveSpeed);
        }

        void FleeMove()
        {
            if (distanceToPlayer <= ViewDistance)
            {
                if (Player.Player._Instance != null)
                {
                    Transform player = Player.Player._Instance.transform;
                    moveDir = Vector3.Normalize(this.transform.position - player.position);
                }
            }
            this.transform.Translate(moveDir * Time.deltaTime * moveSpeed);
        }

        private void OnDestroy()
        {
            if (TouchFX != null)
            {
                Instantiate(TouchFX).transform.position = this.transform.position;
            }
        }

    }

    public enum MoveType
    {
        Null,//不运动
        Random,//随机运动
        Approach,//接近Player
        Flee //逃离Player
    }
}
