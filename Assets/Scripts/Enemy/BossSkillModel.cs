using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace WolfFighter.Base
{
    /// <summary>
    /// BOSS技能基类
    /// </summary>
    public abstract class BossSkillModel : MonoBehaviour
    {

        /// <summary>
        /// 技能名称
        /// </summary>
        public string skillName;
        /// <summary>
        /// 技能咏唱所需要的时间
        /// </summary>
        public float skillProgress;
        /// <summary>
        /// 技能的执行效果事件
        /// </summary>
        public UnityAction skillFunc;

    }

}
