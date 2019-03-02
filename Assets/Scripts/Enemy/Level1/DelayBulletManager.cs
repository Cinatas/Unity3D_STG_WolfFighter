using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Player;

namespace WolfFighter.Level1
{
    public class DelayBulletManager : MonoBehaviour
    {
        public static DelayBulletManager _Instance = null;

        public GameObject[] bulletPrefabs;
        

        private void Awake()
        {
            _Instance = this;
        }

        public EnemyBullet GenerateDelayBullet(Vector3 pos,float delayTime)
        {
            int bulletIndex = Random.Range(0, bulletPrefabs.Length);
            GameObject bulletObj = Instantiate(bulletPrefabs[bulletIndex]);
            bulletObj.transform.position = pos;
            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            bullet.BulletDamage = 30;
            return bullet;
        }
    }

}
