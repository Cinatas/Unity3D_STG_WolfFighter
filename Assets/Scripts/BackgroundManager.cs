using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Base
{
    public class BackgroundManager : MonoBehaviour
    {
        public static BackgroundManager _Instance = null;
        private Transform firstPart;
        private Transform secondPart;
        public float moveSpeed;
        private void Awake()
        {
            firstPart = this.transform.Find("FirstPart");
            secondPart = this.transform.Find("SecondPart");
        }

        private void Start()
        {
            firstPart.gameObject.AddComponent<BackgroundMeta>().moveSpeed = moveSpeed;
            secondPart.gameObject.AddComponent<BackgroundMeta>().moveSpeed = moveSpeed;
        }

    }


    public class BackgroundMeta : MonoBehaviour
    {
        public float moveSpeed;
        private void FixedUpdate()
        {
            if (this.transform.localPosition.y <= -20)
            {
                this.transform.localPosition = new Vector3(0, 32.42f, 0);                
            }
            else
            {
                this.transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
        }
    }
}
