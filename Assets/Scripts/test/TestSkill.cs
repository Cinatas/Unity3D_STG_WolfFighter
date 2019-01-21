using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.UI.PlayerInfo;

namespace WolfFighter.Test
{
    public class TestSkill : Skill
    {

        // Use this for initialization
        void Start()
        {
            
        }

        private void OnEnable()
        {
            this.skillFunc += CastSkillFunc;
        }

        private void OnDisable()
        {
            this.skillFunc -= CastSkillFunc;
        }

        void CastSkillFunc()
        {
            Player.Player._Instance.RecoverHp(20);
        }
    }

}
