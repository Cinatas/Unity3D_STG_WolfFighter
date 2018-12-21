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

        private void Update()
        {
            hp = playerLO.Hp;
            mp = playerLO.MP;
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

        void ScoreReward()
        {
            
        }
    }

}
