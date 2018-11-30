using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class EnemyGirl : MonoBehaviour
    {
        public GameObject deadFX;
        Enemy enemy;
        private void Awake()
        {
            enemy = this.GetComponent<Enemy>();
        }

        private void Start()
        {
            enemy.Hp = 5;
            enemy.Speed = 1.5f;
            enemy.DestroyFX = deadFX;
        }
    }
}
