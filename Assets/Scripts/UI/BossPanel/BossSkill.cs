using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace WolfFighter.UI.Boss
{
    public class BossSkill : MonoBehaviour
    {
        public Image bossSkillFrame;
        public Image bossSkillValue;
        public Text bossSkillName;

        public float ratio = 0;
        
        private void Start()
        {
            ratio = 0;
            HideSkillPanel();
        }

        private void Update()
        {
            bossSkillValue.fillAmount = ratio;
        }

        /// <summary>
        /// 更改技能名
        /// </summary>
        /// <param name="skillName"></param>
        public void ChangeSkillName(string skillName)
        {
            bossSkillName.text = "";
            bossSkillName.DOText(skillName, 0.25f);
        }

        /// <summary>
        /// 调整施法进度条
        /// </summary>
        /// <param name="ratio"></param>
        public void ChangeSkillProgress(float r)
        {
            ratio = r;
        }

        public void FillSkillProgressInTime(float duration)
        {
            ShowSkillPanel();

            DOTween.To(() => ratio, x => ratio = x, 1, duration).SetEase(Ease.Linear)
                .OnComplete(() => HideSkillPanel());

        }

        void HideSkillPanel()
        {
            bossSkillFrame.enabled = false;
            bossSkillValue.enabled = false;
            bossSkillName.enabled = false;
        }

        void ShowSkillPanel()
        {
            bossSkillFrame.enabled = true;
            bossSkillValue.enabled = true;
            bossSkillName.enabled = true;
        }
    }

}
