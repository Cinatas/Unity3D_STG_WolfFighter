using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WolfFighter.UI.PlayerInfo;

namespace WolfFighter.UI
{
    public class PlayerInfoPanel : MonoBehaviour
    {
        public HpFrame hpFrame;
        public MpFrame mpFrame;
        public ExpFrame expFrame;
        public SkillPanel skillPanel;
        private void Awake()
        {
            hpFrame = this.GetComponentInChildren<HpFrame>();
            mpFrame = this.GetComponentInChildren<MpFrame>();
            expFrame = this.GetComponentInChildren<ExpFrame>();
            skillPanel = this.GetComponentInChildren<SkillPanel>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
