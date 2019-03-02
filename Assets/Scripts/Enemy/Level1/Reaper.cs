using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using WolfFighter.Player;

namespace WolfFighter.Level1
{
    public class Reaper : MonoBehaviour
    {

        private void Start()
        {
            StartCoroutine(Chasing(1));
            this.transform.GetComponent<EnemyBullet>().BulletDamage = 20;
        }

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(Vector3.forward, - Time.deltaTime * 750);          
        }

        void ChasePlayer()
        {
            if(Player.Player._Instance != null)
            {
                this.transform.DOMove(Player.Player._Instance.transform.position, 3).SetEase(Ease.InCubic).OnComplete(()=>
                {
                    StartCoroutine(Chasing(2));
                });
            }
        }

        IEnumerator Chasing(float t)
        {
            yield return new WaitForSeconds(t);
            ChasePlayer();
        }
    }

}
