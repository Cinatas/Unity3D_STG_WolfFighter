using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using WolfFighter.Player;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class DefendCircle : MonoBehaviour
    {
        public GameObject[] bullets;

        private void Start()
        {
            this.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            this.transform.DOScale(1, 1f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                GameObject obj = collision.gameObject;
                Vector3 objPos = obj.transform.position;
                BulletBase enemyBullet = obj.GetComponent<BulletBase>();
                MedeaMark mark = obj.GetComponent<MedeaMark>();
                if (enemyBullet != null && mark== null)
                {
                    Destroy(enemyBullet.gameObject);
                    Shoot(objPos);
                }
            }
        }

        private void FixedUpdate()
        {
            this.transform.Rotate(Vector3.forward, Time.deltaTime * 10);
        }

        void Shoot(Vector3 startPos)
        {
            int randomIndex = Random.Range(0, bullets.Length);
            GameObject bulletObj = Instantiate(bullets[randomIndex]);
            bulletObj.AddComponent<MedeaMark>();
            bulletObj.transform.position = startPos;
            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            bullet.DelayLaunch(1, false);
            bullet.SetTarget(Player.Player._Instance.transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0));
        }
    }


    public class MedeaMark:MonoBehaviour
    {

    }
}
