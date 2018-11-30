using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.UI
{
    public class UIManager : MonoBehaviour
    {
        private static UIManager _Instance = null;

        public Canvas canvas = null;

        public GameObject ScoreModule;
        public GameObject PlayerModule;
        public GameObject BossModule;

        private void Awake()
        {
            _Instance = this;
            
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
