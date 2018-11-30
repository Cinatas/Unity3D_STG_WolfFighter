using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace WolfFighter.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIPanel : MonoBehaviour
    {
        protected RectTransform rectTransform;
        public UIPanel lastPanel;

        protected virtual void Awake()
        {
            rectTransform = this.GetComponent<RectTransform>();
        }
         
        public void EnablePanel(UIPanel parentPanel = null)
        {
            this.lastPanel = parentPanel;
            this.gameObject.SetActive(true);            
        }

        public void DisablePanel()
        {
            if (lastPanel != null)
                lastPanel.EnablePanel();
            this.gameObject.SetActive(false);
        }
    }

}
