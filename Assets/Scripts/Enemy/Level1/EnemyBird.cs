using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
using WolfFighter.Player;
namespace WolfFighter.Level1
{
    public class EnemyBird : MonoBehaviour
    {
        Enemy bird;
        public int initTime;
        Animator aniCon;
        Vector2 MoveDir;
        public GameObject bulletPrefab;
        public GameObject deadFX;
        private void Awake()
        {
            bird = this.GetComponent<Enemy>();
            aniCon = this.GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(Movement());
            bird.DestroyFX = deadFX;
        }

        private void FixedUpdate()
        {
            bird.Move(MoveDir * Time.deltaTime);
        }

        void Fly(FlyDirection dir)
        {
            switch (dir)
            {
                case FlyDirection.Up:
                    aniCon.SetTrigger("Up");
                    MoveDir = Vector2.up;
                    break;
                case FlyDirection.Down:
                    aniCon.SetTrigger("Down");
                    MoveDir = Vector2.down;
                    break;
                case FlyDirection.Left:
                    aniCon.SetTrigger("Left");
                    MoveDir = Vector2.left;
                    break;
                case FlyDirection.Right:
                    aniCon.SetTrigger("Right");
                    MoveDir = Vector2.right;
                    break;
                default:
                    break;
            }
        }

        IEnumerator Movement()
        {
            yield return new WaitForSeconds(initTime);

            MoveDir = Vector2.down;
            Fly(FlyDirection.Down);
            bird.Speed = 2;

            yield return new WaitForSeconds(initTime/2f+Random.Range(2f,3f));

            int choice = Random.Range(0, 2);
            if (choice == 0)
            {
                Fly(FlyDirection.Left);
            }
            else
            {
                Fly(FlyDirection.Right);
            }
            bird.Speed = 1.5f;

            if (WolfFighter.Player.Player._Instance != null)
            {
                GameObject bulletObj = Instantiate(bulletPrefab);
                bulletObj.transform.position = this.transform.position;
                BulletBase bullet = bulletObj.GetComponent<BulletBase>();
                Vector2 dir = Vector3.Normalize(WolfFighter.Player.Player._Instance.transform.position - this.transform.position);
                bullet.MoveSpeed = bird.Speed * 2;
                bullet.MoveDirection = dir;
            }
        }
    }

    public enum FlyDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
