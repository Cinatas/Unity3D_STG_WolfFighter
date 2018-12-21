using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;
namespace WolfFighter.UI.PlayerInfo
{
    public class HpFrame : MonoBehaviour
    {
        //背景
        Image hpFrameImage;
        //显示当前生命值
        Image hpValueImage;
        //处于受伤CD时显示
        Image hpFxImage;

        ReactiveProperty<float> tempHp = new ReactiveProperty<float>();

        private void Awake()
        {
            hpFrameImage = this.GetComponent<Image>();
            hpValueImage = this.transform.Find("Value").GetComponent<Image>();
            hpFxImage = this.transform.Find("Value/FX").GetComponent<Image>();
        }

        // Use this for initialization
        void Start()
        {
            HurtFX(false);
            tempHp.Subscribe(hp=>
            {
                hpValueImage.DOFillAmount(hp, GameManager._Instance.HurtCoolDownTime);
            });
        }

        // Update is called once per frame
        void Update()
        {
            if (Player.Player._Instance == null)
                return;
            tempHp.Value = Player.Player._Instance.HpRatio;
            
        }

        public void HurtFX(bool state)
        {
            hpFxImage.enabled = state;
        }
    }

}
