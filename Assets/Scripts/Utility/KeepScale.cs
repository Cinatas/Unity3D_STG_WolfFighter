using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    /// <summary>
    /// 用于保护子物体在父物体Scale变动的情形下调整至视觉外观不变的Scale
    /// </summary>
    [ExecuteInEditMode]
    public class KeepScale : MonoBehaviour
    {
        void Update()
        {
            if (this.transform.parent == null)
                return;
            Vector3 parentScale = this.transform.parent.localScale;
            if(parentScale.x!=0 && parentScale.y!=0&& parentScale.z != 0)
            {
                this.transform.localScale = new Vector3(1f / parentScale.x, 1f / parentScale.y, 1f / parentScale.z);
            }           
        }
    }
}
