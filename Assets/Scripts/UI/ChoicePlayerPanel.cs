using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace WolfFighter.UI
{
    public class ChoicePlayerPanel : UIPanel
    {
        public Button Player1Button;
        public UIPanel ChoiceLevelPanel;

        public Button ReturnButton;
        public UIPanel ReturnPanel;

        protected override void Awake()
        {
            base.Awake();
            if (Player1Button == null)
                Player1Button = this.transform.Find("Player1Button").GetComponent<Button>();
            Player1Button.onClick.AddListener(OnClickChoicePlayerButton);

            if (ReturnButton == null)
                ReturnButton = this.transform.Find("ReturnButton").GetComponent<Button>();
            ReturnButton.onClick.AddListener(OnClickReturnButton);
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClickChoicePlayerButton()
        {

        }

        void OnClickReturnButton()
        {
            this.DisablePanel();
        }
    }

}
