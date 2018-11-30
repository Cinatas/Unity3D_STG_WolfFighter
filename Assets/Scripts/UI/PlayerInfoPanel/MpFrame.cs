using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WolfFighter.UI.PlayerInfo
{
    public class MpFrame : MonoBehaviour
    {
        //背景
        Image mpFrameImage;
        //显示当前魔法值
        Image mpValueImage;
        //处于禁魔CD时显示
        Image mpFxImage;

        private void Awake()
        {
            mpFrameImage = this.GetComponent<Image>();
            mpValueImage = this.transform.Find("Value").GetComponent<Image>();
            mpFxImage = this.transform.Find("Value/FX").GetComponent<Image>();
        }

        // Use this for initialization
        void Start()
        {
            Silent(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Player.Player._Instance == null) return;
            mpValueImage.fillAmount = Player.Player._Instance.MpRatio;
        }

        public void Silent(bool state)
        {
            mpFxImage.enabled = state;
        } 
    }

}
