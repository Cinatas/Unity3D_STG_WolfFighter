using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.UI;

namespace WolfFighter.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager _Instance = null;

        public Canvas canvas = null;

        public PlayerInfoPanel playerInfoPanel;
        public DialogPanel dialogPanel;
        public ScorePanel scorePanel;
        public BossPanel bossPanel;
        private void Awake()
        {
            _Instance = this;
            playerInfoPanel = canvas.GetComponentInChildren<PlayerInfoPanel>();
            dialogPanel = canvas.GetComponentInChildren<DialogPanel>();
            scorePanel = canvas.GetComponentInChildren<ScorePanel>();
            bossPanel = canvas.GetComponentInChildren<BossPanel>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

       
    }

}
