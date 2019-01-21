using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Player
{
    public class EnemyBullet : BulletBase
    {

        public void SetTarget(Transform dest)
        {
            if (dest != null)
                this.MoveDirection = Vector3.Normalize(dest.position - this.transform.position);
        }

        public void DelayLaunch(float time = 0,bool lockPlayer = false)
        {
            if (lockPlayer)
            {
                SetTarget(Player._Instance.transform);
            }            
            StartCoroutine(Delay(time));
        }

        IEnumerator Delay(float delayTime)
        {
            float tempSpeed = this.MoveSpeed;
            this.MoveSpeed = 0;
            yield return new WaitForSeconds(delayTime);
            this.MoveSpeed = tempSpeed;
        }

    }

}
