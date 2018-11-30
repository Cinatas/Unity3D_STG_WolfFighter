using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class FrogBullet : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            this.transform.localEulerAngles += new Vector3(0, 0, Time.deltaTime);
        }
    }

}
