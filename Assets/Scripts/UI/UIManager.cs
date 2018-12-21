using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager _Instance = null;

        public Canvas canvas = null;

        public PlayerInfoPanel playerInfoPanel;



        private void Awake()
        {
            _Instance = this;
            playerInfoPanel = canvas.GetComponentInChildren<PlayerInfoPanel>();
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
