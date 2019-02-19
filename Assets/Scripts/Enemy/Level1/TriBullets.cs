using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Player;

namespace WolfFighter.Level1
{
    public class TriBullets : MonoBehaviour
    {
        public float angle;
        Transform middle, left, right;

        public GameObject[] bulletPrefabs;
        private void Awake()
        {
            middle = this.transform.Find("Middle");
            left = this.transform.Find("Left");
            right = this.transform.Find("Right");

        }

        // Use this for initialization
        void Start()
        {
            GameObject bulletLObj = Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Length)]);
            GameObject bulletMObj = Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Length)]);
            GameObject bulletRObj = Instantiate(bulletPrefabs[Random.Range(0, bulletPrefabs.Length)]);

            bulletLObj.transform.position = left.position;
            bulletRObj.transform.position = right.position;
            bulletMObj.transform.position = middle.position;

            EnemyBullet bulletL = bulletLObj.GetComponent<EnemyBullet>();
            EnemyBullet bulletM = bulletMObj.GetComponent<EnemyBullet>();
            EnemyBullet bulletR = bulletRObj.GetComponent<EnemyBullet>();

            bulletM.MoveDirection = new Vector2(0, -1);
            bulletL.MoveDirection = new Vector2(-1 * Mathf.Sin(Mathf.Deg2Rad * angle), -1 * Mathf.Cos(Mathf.Deg2Rad * angle));
            bulletR.MoveDirection = new Vector2(+1 * Mathf.Sin(Mathf.Deg2Rad * angle), -1 * Mathf.Cos(Mathf.Deg2Rad * angle));
        }
    }
}
