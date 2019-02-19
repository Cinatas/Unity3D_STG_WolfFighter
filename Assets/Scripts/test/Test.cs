using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Level1;
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

        private void OnGUI()
        {
            if (GUILayout.Button("on"))
            {
                BossMedea._Instance.Show();
            }

            if (GUILayout.Button("off"))
            {
                BossMedea._Instance.Hide();

            }

            if (GUILayout.Button("launch"))
            {
                // IceArrowManager._Instance.GenerateIce(5, 5);
                BlackBallManager._Instance.GenerateBlackBall(new Vector3(1,1,1)).MoveToMiddlePosition();
            }
        }
    }
}

