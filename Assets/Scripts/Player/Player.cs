using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;

namespace WolfFighter.Player
{
    public class Player : MonoBehaviour
    {
        public static Player _Instance = null;

        LivingObject playerLO;

        private int hp;
        private int mp;

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
    }

}
