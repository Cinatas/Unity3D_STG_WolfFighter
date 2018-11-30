using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    public class DontDestory : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }


    }

}
