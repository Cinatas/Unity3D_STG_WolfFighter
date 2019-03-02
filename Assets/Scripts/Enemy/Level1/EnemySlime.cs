using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Level1
{
    public class EnemySlime : Enemy
    {
        [SerializeField]
        GameObject bulletPrefab;

        protected override void Start()
        {
            base.Start();
            this.Hp = 10;
        }

        public void Shoot(Vector3 des)
        {
            GameObject bulletObj = Instantiate(bulletPrefab);
            bulletObj.transform.position = this.transform.position;
            BulletBase bullet = bulletObj.GetComponent<BulletBase>();
            bullet.MoveSpeed = 4;
            //if (Player.Player._Instance != null)
            //    bullet.MoveDirection = Vector3.Normalize(Player.Player._Instance.transform.position - this.transform.position);
            bullet.MoveDirection = Vector3.Normalize(des - this.transform.position);
            bullet.BulletDamage = 15;
            Destroy(bulletObj, 60);
        }

        private void FixedUpdate()
        {
            this.transform.eulerAngles = Vector3.zero;
            this.transform.localScale = new Vector3(
                1f / this.transform.parent.localScale.x,
                1f / this.transform.parent.localScale.y,
                1f / this.transform.parent.localScale.z);
        }
    }
}
