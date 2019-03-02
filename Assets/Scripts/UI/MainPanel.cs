using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace WolfFighter.UI
{
    public class MainPanel : UIPanel
    {
        public Button StartGameButton;
        public UIPanel StartGamePanel;
        public Button OptionButton;
        public UIPanel OptionPanel;
        public Button ExitButton;
        public UIPanel ExitPanel;

        // Use this for initialization
        void Start()
        {
            if (StartGameButton == null)
                StartGameButton = this.transform.Find("StartGameButton").GetComponent<Button>();
            StartGameButton.onClick.AddListener(OnClickStartGameButton);

            if (OptionButton == null)
                OptionButton = this.transform.Find("OptionButton").GetComponent<Button>();
            OptionButton.onClick.AddListener(OnClickOptionButton);

            if (ExitButton == null)
                ExitButton = this.transform.Find("ExitButton").GetComponent<Button>();
            ExitButton.onClick.AddListener(OnClickExitButton);
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnClickStartGameButton()
        {
            SceneManager.LoadScene(1);
            //StartGamePanel.EnablePanel();
            //StartGamePanel.lastPanel = this;
            //this.DisablePanel();
        }

        void OnClickOptionButton()
        {

        }

        void OnClickExitButton()
        {

        }
    }

}
