using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using UniRx;
using UniRx.Triggers;
using WolfFighter.Player;

namespace WolfFighter.Test
{
    public class TestInput : MonoBehaviour
    {
        public Marisa controller;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            InputFunc();
        }

        void InputFunc()
        {
            float horizental = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 deltaPos = Vector2.right * horizental + Vector2.up * vertical;
            Vector2 checkPos = (Vector2)controller.transform.position + deltaPos * 0.1f;
            if (controller.isInRestrictedArea(checkPos))
            {
                controller.Move(deltaPos);
            }

            float fire = Input.GetAxis("Fire1");
            if (fire > 0)
                controller.Fire();
        }
    }
}
