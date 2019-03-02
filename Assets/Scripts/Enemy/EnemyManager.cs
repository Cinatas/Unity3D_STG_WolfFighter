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

        private void Awake()
        {
            _Instance = this;
        }

        // Use this for initialization
        IEnumerator Start()
        {
            SoundManager._Instance.PlayBGM(1);
            yield return new WaitForSeconds(4);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[1]);
            yield return new WaitForSeconds(11);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[2]);
            yield return new WaitForSeconds(14);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[3]);
            yield return new WaitForSeconds(19);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[4]);
            yield return new WaitForSeconds(17);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[6]);
            yield return new WaitForSeconds(32);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[7]);
            yield return new WaitForSeconds(18);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[8]);
            yield return new WaitForSeconds(17);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[5]);
            yield return new WaitForSeconds(2);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[9]);
            yield return new WaitForSeconds(16);
            Instantiate(ResourceManager._Instance.EnemyWavesInLevel1[10]);
            yield return new WaitForSeconds(18);
            StartCoroutine(MedeaStageIn());
        }

        /// <summary>
        /// 美狄亚对话+登场
        /// </summary>
        IEnumerator MedeaStageIn()
        {
            UIManager._Instance.dialogPanel.ShowDialog(DialogType.LeftDialog, "c010", "Welcome to my trail little girl");
            yield return new WaitForSeconds(7);
            UIManager._Instance.dialogPanel.HideDialog(DialogType.LeftDialog);
            UIManager._Instance.dialogPanel.ShowDialog(DialogType.LeftDialog, "c008", "Come at me and stay alive");
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
            foreach (var i in Enemy.currentList)
            {
                i.GetComponent<Enemy>().Die();
            }
        }

    }

}