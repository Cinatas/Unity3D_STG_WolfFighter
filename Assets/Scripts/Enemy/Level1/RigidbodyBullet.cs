using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class RigidbodyBullet : MonoBehaviour
    {
        Rigidbody2D rigid2D;
        public Vector2 force;
        private void Awake()
        {
            rigid2D = this.GetComponent<Rigidbody2D>();
        }

        // Use this for initialization
        void Start()
        {
            rigid2D.AddForce(force);
        }
    }

}
