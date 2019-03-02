using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.UI.Boss;
using DG.Tweening;

namespace WolfFighter.UI
{
    public class BossPanel : MonoBehaviour
    {
        CanvasGroup self;
        BossHp bossHp;
        BossSkill bossSkill;
        bool isEnable;

        public static BossPanel _Instance = null;

        public int hpMax = 108;
        private int hp = 108;
        public int BossHp
        {
            get
            {
                return hp;
            }

            set
            {
                if (hp != value)
                {
                    hp = value;
                    ChangeHpRatio();
                }
            }
        }
              

        private void Awake()
        {
            _Instance = this;
            bossHp = this.GetComponentInChildren<BossHp>();
            bossSkill = this.GetComponentInChildren<BossSkill>();
            self = this.GetComponent<CanvasGroup>();           
        }

        // Use this for initialization
        void Start()
        {
            isEnable = false;
            ChangeBossPanelState(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 显示或关闭BossPanel
        /// </summary>
        /// <param name="s"></param>
        public void ChangeBossPanelState(bool s)
        {
            isEnable = s;
            if (isEnable)
            {
                self.DOFade(1, 0.5f);
            }
            else
            {
                self.DOFade(0, 0.5f);
            }
        }
        
        void ChangeHpRatio()
        {
            float ratio = (float)hp / (float)hpMax;
            bossHp.ChangeHp(ratio);
            print("Ratio to " + ratio);
        }

        public void ChangeSkillName(string skillName)
        {
            bossSkill.ChangeSkillName(skillName);
        }

        public void ChangeSkillProgress(float progress)
        {
            bossSkill.ChangeSkillProgress(progress);
        }

        public void SkillProgressFillInTime(float duration)
        {
            bossSkill.FillSkillProgressInTime(duration);
        }

        public void StartBossTimer()
        {
            //以每秒一点的速度减少HP
            StartCoroutine(TimerCount());
        }

        IEnumerator TimerCount()
        {
            hp = hpMax;
            while (true)
            {
                hp--;
                ChangeHpRatio();
                yield return new WaitForSeconds(1);
            }
        }
    }

}
