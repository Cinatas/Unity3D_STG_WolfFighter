using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WolfFighter.UI
{
    public class LoadingProgress : MonoBehaviour
    {
        Image img;

        private void Awake()
        {
            img = this.GetComponent<Image>();
        }

        // Update is called once per frame
        void Update()
        {
            img.fillAmount = ResourceManager._Instance.processRatio;
        }
    }

}
