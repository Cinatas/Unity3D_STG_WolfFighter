using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using UniRx;

namespace WolfFighter.Player
{
    public class Player : MonoBehaviour
    {
        public static Player _Instance = null;

        LivingObject playerLO;

        private int hp;
        private int mp;
        private int lv;

        private int exp;
        private int expMax = 10000;
        public int Hp
        {
            get
            {
                return hp;
            }
        }

        public int Mp
        {
            get
            {
                return mp;
            }
        }

        public int Exp

        {
            get
            {
                return exp;
            }
        }
        public float HpRatio
        {
            get
            {
                return Hp / 100f;
            }
        }

        public float MpRatio
        {
            get
            {
                return Mp / 100f;
            }
        }

        public float ExpRatio
        {
            get
            {
                return (float)exp / (float)expMax;
            }
        }

        private void Awake()
        {
            _Instance = this;
            playerLO = this.GetComponent<LivingObject>();
        }

        private void Start()
        {
            //对于玩家来说，HP MP上限永远是100，lv影响MP的恢复速率
            lv = 1;
            playerLO.Hp = 100;
            playerLO.Mp = 100;
        }

        private void Update()
        {
            hp = playerLO.Hp;
            mp = playerLO.Mp;
        }

        public void RecoverHp(int healHp)
        {
            playerLO.Heal(healHp);
        }

        public void RecoverMp(int mpValue)
        {
            playerLO.Charge(mpValue);
        }

        public void GainScoreAndExp(int score)
        {
            exp += score;
            if (exp > expMax)
            {
                expMax = expMax * 2;
                ScoreReward();
            }
        }

        public void CostMp(int cost)
        {
            print("消耗Mp:" + cost);
            playerLO.Mp -= cost;
            if (this.mp < 0)
                this.mp = 0;
        }

        void ScoreReward()
        {
            lv++;
            playerLO.Mp = playerLO.Hp = 100;
        }
    }

}
