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
            this.transform.localEulerAngles = new Vector3(0.1f, 0.1f, 0.1f);
            this.transform.DOScale(1, 1f);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision != null)
            {
                GameObject obj = collision.gameObject;
                Vector3 objPos = obj.transform.position;
                MarisaBullet enemyBullet = obj.GetComponent<MarisaBullet>();
                if (enemyBullet != null)
                {
                    Destroy(enemyBullet.gameObject);
                    Shoot(objPos);
                }
            }
        }

        void Shoot(Vector3 startPos)
        {
            int randomIndex = Random.Range(0, bullets.Length);
            GameObject bulletObj = Instantiate(bullets[randomIndex]);
            bulletObj.transform.position = startPos;
            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            bullet.DelayLaunch(1, false);
            bullet.SetTarget(Player.Player._Instance.transform.position + new Vector3(Random.Range(-1f,1f), Random.Range(-1f, 1f), 0));
        }
    }

}
