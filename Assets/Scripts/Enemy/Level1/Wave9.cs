using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class Wave9 : MonoBehaviour
    {
        public EnemyBlackBird bird1;
        public float delayTime1;
        public EnemyBlackBird bird2;
        public float delayTime2;
        public EnemyBlackBird bird3;
        public float delayTime3;
        public EnemyBlackBird bird4;
        public float delayTime4;
        public EnemyBlackBird bird5;
        public float delayTime5;
        public EnemyBlackBird bird6;
        public float delayTime6;

        private void Awake()
        {
            bird1.gameObject.SetActive(false);
            bird2.gameObject.SetActive(false);
            bird3.gameObject.SetActive(false);
            bird4.gameObject.SetActive(false);
            bird5.gameObject.SetActive(false);
            bird6.gameObject.SetActive(false);
        }

        // Use this for initialization
        void Start()
        {
            StartCoroutine(EnableBird(bird1.gameObject, delayTime1));
            StartCoroutine(EnableBird(bird2.gameObject, delayTime2));
            StartCoroutine(EnableBird(bird3.gameObject, delayTime3));
            StartCoroutine(EnableBird(bird4.gameObject, delayTime4));
            StartCoroutine(EnableBird(bird5.gameObject, delayTime5));
            StartCoroutine(EnableBird(bird6.gameObject, delayTime6));
        }

        IEnumerator EnableBird(GameObject birdObj,float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            birdObj.SetActive(true);
        }
    }
}
