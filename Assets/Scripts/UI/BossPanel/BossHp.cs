using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WolfFighter.Level1;

namespace WolfFighter.UI.Boss
{
    public class BossHp : MonoBehaviour
    {
        public Image bossHpFrame;
        public Image bossHpValue;
        public Image bossHpText;
        
        /// <summary>
        /// 按百分比调整Hp
        /// </summary>
        /// <param name="ratio"></param>
        public void ChangeHp(float ratio)
        {
            bossHpValue.fillAmount = ratio;
        }
    }

}
