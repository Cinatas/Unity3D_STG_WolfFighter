using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

namespace WolfFighter.UI.PlayerInfo
{
    public class SkillSlot : MonoBehaviour
    {
        private Image skillIcon;
        private Image cdImage;

        private GameObject SkillObj;
        private Skill currentSkill
        {
            get
            {
                Skill tempSkill = SkillObj.GetComponent<Skill>();
                if (tempSkill != null)
                    return tempSkill;
                else
                    return null;
            }
        }
        private SkillSlotState slotState;

        public UnityAction CurrentSkillFunc;

        public KeyCode activeKey;

        private void Awake()
        {
            skillIcon = this.transform.Find("Icon").GetComponent<Image>();
            cdImage = this.transform.Find("Cooldown").GetComponent<Image>();
        }

        // Use this for initialization
        void Start()
        {
            if (SkillObj == null)
            {
                slotState = SkillSlotState.Null;
            }
            cdImage.fillAmount = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(activeKey))
            {
                CastCurrentSkill();
            }
        }

        public void LoadSkill(GameObject sObj)
        {
            if (this.SkillObj == null)
                this.SkillObj = sObj;

            this.SkillObj = Instantiate(this.SkillObj);

            this.CurrentSkillFunc = this.currentSkill.skillFunc;
            this.skillIcon.sprite = this.currentSkill.icon;
            this.skillIcon.color = Color.white;
            this.slotState = SkillSlotState.Ready;
        }

        public void CastCurrentSkill()
        {
            //进行MP判定
            int currentMp = Player.Player._Instance.Mp;
            if(currentMp>= this.currentSkill.mpCost)
            {
                if (this.slotState == SkillSlotState.Ready)
                {
                    Player.Player._Instance.CostMp(this.currentSkill.mpCost);
                    this.CurrentSkillFunc();
                    this.slotState = SkillSlotState.CoolDowning;
                    StartCoroutine(StartCoolDown());
                }
            }
            else
            {
                //Mp不足
            }
        }

        IEnumerator StartCoolDown()
        {
            float time = this.currentSkill.cdTime;
            cdImage.fillAmount = 1;
            cdImage.DOFillAmount(0, time);
            yield return new WaitForSeconds(time);

            this.slotState = SkillSlotState.Ready;
        }

        public void RemoveSkill()
        {
            Destroy(this.SkillObj);
            this.SkillObj = null;
            this.skillIcon.sprite = null;
            this.skillIcon.color = new Color(1, 1, 1, 0);
        }
    }

    public enum SkillSlotState
    {
        Null,
        CoolDowning,
        Ready
    }
}
