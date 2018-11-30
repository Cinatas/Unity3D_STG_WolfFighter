using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WolfFighter.UI.PlayerInfo
{
    public class ExpFrame : MonoBehaviour
    {
        Image expFrame;
        Image expValue;

        private void Awake()
        {
            expFrame = this.GetComponent<Image>();
            expValue = this.transform.Find("Value").GetComponent<Image>();
        }

    }

}
