using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;
using System;
using WolfFighter.UI;
using WolfFighter.Base;

namespace WolfFighter.Level1
{
    /// <summary>
    /// Enemy管理器脚本，每关都有一个，用于管理各种敌人的生成
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {

        public static EnemyManager _Instance = null;

        private int globalTimer;

        Dictionary<int, UnityAction> eventMap;
        //public ReactiveProperty<int> GlobalTimer;
        //public IntReactiveProperty GlobalTimer;

        public int GlobalTimer
        {
            get
            {
                return globalTimer;
            }
            set
            {
                if (globalTimer != value)
                {
                    Tick();
                    globalTimer = value;
                }
            }
        }

        private void Awake()
        {
            _Instance = this;
            eventMap = new Dictionary<int, UnityAction>();
        }

        // Use this for initialization
        void Start()
        {
            globalTimer = 0;

            eventMap.Add(0, () => SoundManager._Instance.PlayBGM(1));
            eventMap.Add(4, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[1]));
            eventMap.Add(15, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[2]));
            eventMap.Add(29, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[3]));
            eventMap.Add(48, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[4]));
            eventMap.Add(65, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[6]));
            eventMap.Add(97, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[7]));
            eventMap.Add(115, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[8]));
            eventMap.Add(132, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[5]));
            eventMap.Add(134, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[9]));
            eventMap.Add(150, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[10]));

            //168
           // eventMap.Add(5, () => StartCoroutine(MedeaStageIn()));
            eventMap.Add(168, () => StartCoroutine(MedeaStageIn()));
        }


        void Tick()
        {
            print("Time = " + GlobalTimer);
            CheckEvent();
        }

        void CheckEvent()
        {
            UnityAction currentEvent;
            if (eventMap.TryGetValue(GlobalTimer, out currentEvent))
            {
                currentEvent();
            }
        }

        private void Update()
        {
            GlobalTimer = (int)Time.time; 
        }

        /// <summary>
        /// 美狄亚对话+登场
        /// </summary>
        IEnumerator MedeaStageIn()
        {
            UIManager._Instance.dialogPanel.ShowDialog(DialogType.LeftDialog, "c010", "Another thief casts her covetous eyes on my Book ?");
            yield return new WaitForSeconds(7);
            UIManager._Instance.dialogPanel.HideDialog(DialogType.LeftDialog);
            UIManager._Instance.dialogPanel.ShowDialog(DialogType.LeftDialog, "c008", "Come and show me how good you really are.");
            yield return new WaitForSeconds(7);
            UIManager._Instance.dialogPanel.HideDialog(DialogType.LeftDialog);

            //清全屏小怪
            Instantiate(ResourceManager._Instance.ClearEnemyAndBulletFX).transform.position = new Vector3(0, 2, 0);
            yield return new WaitForSeconds(1f);
            RemoveAllEnemy();
            yield return new WaitForSeconds(1f);

            //Medea登场
            Instantiate(ResourceManager._Instance.Boss1).transform.position = new Vector3(0, 2, 0);
        }

        void RemoveAllBullet()
        {

        }

        void RemoveAllEnemy()
        {
            foreach(var i in Enemy.currentList)
            {
                i.GetComponent<Enemy>().Die();
            }
        }

    }

}
