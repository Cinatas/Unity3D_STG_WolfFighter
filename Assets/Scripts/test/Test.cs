using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.UI;

namespace WolfFighter.Test
{
    public class Test : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameObject skillObj = Resources.Load<GameObject>("Prefab/Skill/TestSkill");
            UIManager._Instance.playerInfoPanel.skillPanel.slot1.LoadSkill(skillObj);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

