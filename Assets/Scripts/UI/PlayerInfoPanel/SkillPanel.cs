using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.UI.PlayerInfo
{
    public class SkillPanel : MonoBehaviour
    {
        [HideInInspector]
        public SkillSlot slot1;
        [HideInInspector]
        public SkillSlot slot2;
        [HideInInspector]
        public SkillSlot slot3;
        [HideInInspector]
        public SkillSlot slot4;
        [HideInInspector]
        public SkillSlot slot5;
        [HideInInspector]
        public SkillSlot slot6;
        [HideInInspector]
        public SkillSlot slot7;
        [HideInInspector]
        public SkillSlot slot8;
        [HideInInspector]
        public SkillSlot slot9;

        private void Awake()
        {
            slot1 = this.transform.Find("Slot1").GetComponent<SkillSlot>();
            slot2 = this.transform.Find("Slot2").GetComponent<SkillSlot>();
            slot3 = this.transform.Find("Slot3").GetComponent<SkillSlot>();
            slot4 = this.transform.Find("Slot4").GetComponent<SkillSlot>();
            slot5 = this.transform.Find("Slot5").GetComponent<SkillSlot>();
            slot6 = this.transform.Find("Slot6").GetComponent<SkillSlot>();
            slot7 = this.transform.Find("Slot7").GetComponent<SkillSlot>();
            slot8 = this.transform.Find("Slot8").GetComponent<SkillSlot>();
            slot9 = this.transform.Find("Slot9").GetComponent<SkillSlot>();
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
