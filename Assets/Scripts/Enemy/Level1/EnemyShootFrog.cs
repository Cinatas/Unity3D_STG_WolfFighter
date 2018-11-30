using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Level1 {
    public class EnemyShootFrog : EnemyFrog
    {
        [SerializeField]
        GameObject bulletPrefab;
        protected override void Start()
        {
            base.Start();
            StartCoroutine(Shoot());
        }

        IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(3f,5f));
                GameObject bulletObj = Instantiate(bulletPrefab);
                bulletObj.transform.position = this.transform.position;
                bulletObj.AddComponent<FrogBullet>();
                BulletBase bullet = bulletObj.GetComponent<BulletBase>();
                bullet.MoveSpeed = 4;
                if (Player.Player._Instance != null)                    
                bullet.MoveDirection = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
                Destroy(bulletObj, 60);
            }
        }
    }
    
}

