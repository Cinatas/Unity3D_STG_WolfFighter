using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WolfFighter.UI
{
    public class ScorePanel : MonoBehaviour
    {
        Text scoreText;
        int currentScore;
        private void Awake()
        {
            scoreText = this.GetComponentInChildren<Text>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Player.Player._Instance != null)
            {
                currentScore = Player.Player._Instance.Score;
            }
            else
            {
                currentScore = 0;
            }
            RefreshScore();
        }

        void RefreshScore()
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
