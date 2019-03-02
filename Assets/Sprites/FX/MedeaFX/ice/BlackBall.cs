using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Player;
using UniRx.Triggers;
using UniRx;
using DG.Tweening;
using WolfFighter.Level1;
using WolfFighter.Utility;

namespace WolfFighter.FX
{
    
    public class BlackBall : MonoBehaviour
    {
        float RotateSpeed = 300;
        Transform gunPoint;
        Vector3 shotDir;
        public GameObject bulletPrefab;
        [HideInInspector]
        public float shotDelay = 0.05f;

        public float moveSpeed;
        public Vector2 moveDirection;

        private Coroutine switchShooting;
        public GameObject destroyFX;
        private void Awake()
        {
            gunPoint = this.transform.Find("GeneratePoint");
           
        }

        private void Start()
        {            
            StartCoroutine(ShotAsyc());
            shotDelay = 0.1f;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            this.transform.Rotate(new Vector3(0, 0, 1), RotateSpeed * Time.deltaTime);
            this.transform.Translate(moveDirection * moveSpeed * Time.deltaTime,Space.World);
        }

        void Launch()
        {
            shotDir = Vector3.Normalize(gunPoint.position - this.transform.position);
            GameObject bulletObj = Instantiate(bulletPrefab);
            bulletObj.transform.position = gunPoint.position;
            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            bullet.MoveDirection = shotDir;
            bullet.MoveSpeed = 5;
        }

        IEnumerator ShotAsyc()
        {
            if (shotDelay < 0.01f)
                shotDelay = 0.01f;
            while (true)
            {
                yield return new WaitForSeconds(shotDelay);
                    Launch();
            }
        }

        /// <summary>
        /// 移动到中场处，（0,0,0），5秒内
        /// </summary>
        public  void MoveToMiddlePosition()
        {
            this.transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 5);
            this.transform.DOMove(new Vector3(0, 0, 0), 5).OnComplete(()=>
            {
                shotDelay /= 1.5f;
            });
        }

        public void DestroyBlackBall()
        {
            if (destroyFX != null)
            {
                Instantiate(destroyFX).transform.position = this.transform.position;
            }
            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            if (destroyFX != null)
            {
                Instantiate(destroyFX).transform.position = this.transform.position;

                ExplodeBullets bullet = ExplodeBulletsManager._Instance.GenerateExplodeBullet(2);
                bullet.transform.position = this.transform.position;
                bullet.selfExtendSpeed = 1f;
                bullet.selfRotateSpeed = 50;
                
            }
        }
    }

}
