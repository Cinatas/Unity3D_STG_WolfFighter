using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    /// <summary>
    /// 绑定在FX动画上，用于在播放结束后销毁自身。
    /// </summary>
    public class DestroyFX : MonoBehaviour
    {
        void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }

}
