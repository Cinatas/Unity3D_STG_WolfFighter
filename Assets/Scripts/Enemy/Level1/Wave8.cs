using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class Wave8 : MonoBehaviour
    {
        public Transform circle1;
        public Transform circle2;

        // Use this for initialization
        void Start()
        {
            circle1.localEulerAngles = new Vector3(0,0,0);
            circle1.gameObject.SetActive(false);
            circle2.localEulerAngles = new Vector3(0, 0,-90);
            circle2.gameObject.SetActive(false);
            StartCoroutine(RotateCircle(9,9));
        }

        // Update is called once per frame
        void Update()
        {

        }

        IEnumerator RotateCircle(float time1,float time2)
        {
            circle1.gameObject.SetActive(true);
            circle1.DOLocalRotate(new Vector3(0, 0, 180), time1).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time1);
            circle1.gameObject.SetActive(false);

            circle2.gameObject.SetActive(true);
            circle2.DOLocalRotate(new Vector3(0,0,-270),time2).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time2);
            circle2.gameObject.SetActive(false);
        }
    }

}
