using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Player;

namespace WolfFighter.Level1
{
    public class BulletLauncher : MonoBehaviour
    {
        public static BulletLauncher _Instance = null;
        public GameObject[] bullets;
        private void Awake()
        {
            _Instance = this;
        }
        
        public EnemyBullet LaunchBullet(Vector3 pos)
        {
            int bulletIndex = Random.Range(0, bullets.Length);
            GameObject bulletObj = Instantiate(bullets[bulletIndex]);
            bulletObj.transform.position = pos;
            EnemyBullet bullet = bulletObj.GetComponent<EnemyBullet>();
            return bullet;
        }
    }

}
