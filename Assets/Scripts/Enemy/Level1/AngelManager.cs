using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Level1;

namespace WolfFighter.level1
{
    public class AngelManager : MonoBehaviour
    {
        public static AngelManager _Instance = null;

        public GameObject leftAngelPrefab;
        public GameObject rightAngelPrefab;
        private void Awake()
        {
            _Instance = this;
        }

        public MedeaLeftAngel GenerateLeftAngel()
        {
            GameObject tempObj = Instantiate(leftAngelPrefab);
            return tempObj.GetComponent<MedeaLeftAngel>();
        }

        public MedeaRightAngel GenerateRightAngel()
        {
            GameObject tempObj = Instantiate(rightAngelPrefab);
            return tempObj.GetComponent<MedeaRightAngel>();
        }
    }

}
