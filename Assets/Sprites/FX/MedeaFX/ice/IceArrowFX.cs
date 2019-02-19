using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.FX
{
    public class IceArrowFX : MonoBehaviour
    {
        public GameObject iceBulletArrowObject;
        private void DestroySelf()
        {
            GenerateIceArrow();
            Destroy(this.gameObject);
        }

        private void GenerateIceArrow()
        {
            if (iceBulletArrowObject != null)
            {
                Instantiate(iceBulletArrowObject).transform.position = this.transform.position;
            }
        }
    }

}
