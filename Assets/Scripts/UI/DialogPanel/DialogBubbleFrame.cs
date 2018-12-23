using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace WolfFighter.UI.Dialog
{
    public class DialogBubbleFrame : MonoBehaviour
    {
        public Text bubbleText;
        // Use this for initialization
        void Start()
        {
            bubbleText = this.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeText(string txt,float duration)
        {
            bubbleText.text = "";
            bubbleText.DOText(txt, duration);
        }
    }

}
