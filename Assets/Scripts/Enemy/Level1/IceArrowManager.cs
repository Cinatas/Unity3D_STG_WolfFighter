using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class IceArrowManager : MonoBehaviour
    {
        public static IceArrowManager _Instance = null;
        public GameObject IceArrowFX;
        public Transform[] poses;

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

        IEnumerator GenerateIceArrow(int count,float duration)
        {
            count = Mathf.Clamp(count, 0, 10);
            if (count == 0)
                yield return null;
            float delay = duration / count;
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(delay);
                int pos = Random.Range(0, 10);
                GameObject iceArrowObj = Instantiate(IceArrowFX);
                iceArrowObj.transform.position = poses[pos].position;
            }
        }

        public void GenerateIce(int count , float duration)
        {
            StartCoroutine(GenerateIceArrow(count, duration));
        }
    }

}
