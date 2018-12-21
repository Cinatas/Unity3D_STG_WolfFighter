using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;
namespace WolfFighter.Level1
{
    /// <summary>
    /// Enemy管理器脚本，每关都有一个，用于管理各种敌人的生成
    /// </summary>
    public class EnemyManager : MonoBehaviour
    {

        public static EnemyManager _Instance = null;

        private int globalTimer;
        public int GlobalTimer
        {
            get
            {
                return globalTimer;
            }
        }

        Dictionary<int, UnityAction> eventMap;


        private void Awake()
        {
            _Instance = this;
            eventMap = new Dictionary<int, UnityAction>();
        }

        // Use this for initialization
        void Start()
        {
            SoundManager._Instance.PlayBGM(1);

            globalTimer = 0;
            this.UpdateAsObservable().SampleFrame(60).Subscribe(_ => Tick());

            eventMap.Add(3, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[1]));
            eventMap.Add(14, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[2]));
            eventMap.Add(28, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[3]));
            eventMap.Add(47, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[4]));
            eventMap.Add(63, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[5]));
            eventMap.Add(65, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[6]));
            eventMap.Add(96, () => Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[7]));
        }

        void Tick()
        {
            CheckEvent();
            globalTimer++;
        }

        void CheckEvent()
        {
            UnityAction currentEvent;
            if (eventMap.TryGetValue(GlobalTimer, out currentEvent))
            {
                currentEvent();
            }
        }

    }

}
