using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.FX;
using WolfFighter.Player;

namespace WolfFighter.Level1
{
    public class BlackBallManager : MonoBehaviour
    {
        public static BlackBallManager _Instance = null;
        public GameObject BlackBallPrefab;
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

        public BlackBall GenerateBlackBall(Vector3 pos)
        {
            GameObject blackBallObj = Instantiate(BlackBallPrefab);
            blackBallObj.transform.position = pos;       
            return blackBallObj.GetComponent<BlackBall>();
        }
    }

}
