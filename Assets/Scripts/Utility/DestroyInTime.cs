using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    public class DestroyInTime : MonoBehaviour
    {
        public float DestroyInSecond;
        // Use this for initialization
        void Start()
        {
            Destroy(this.gameObject, DestroyInSecond);
        }
    }
}
