using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace WolfFighter.Utility
{
    /// <summary>
    /// 用于脏弹控制
    /// </summary>
    public class ExplodeBullets : MonoBehaviour
    {
        public float selfRotateSpeed;
        public float selfExtendSpeed;

        Transform self;

        private void Awake()
        {
            self = this.GetComponent<Transform>();

        }

        private void FixedUpdate()
        {
            self.Rotate(new Vector3(0,0,1) * Time.deltaTime * selfRotateSpeed);
            float selfExtend = selfExtendSpeed * Time.deltaTime;
            self.localScale += new Vector3(selfExtend, selfExtend, 0);
        }
    }

}
