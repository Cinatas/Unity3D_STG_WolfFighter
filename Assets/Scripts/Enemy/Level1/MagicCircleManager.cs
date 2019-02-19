using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WolfFighter.Level1
{
    public class MagicCircleManager : MonoBehaviour
    {
        public static MagicCircleManager _Instance = null;

        public GameObject mcObjPrefab;

        private void Awake()
        {
            _Instance = this;
        }

        public MagicCircle GenerateMagicCircle(Vector3 pos, UnityAction func = null)
        {
            GameObject mcObj = Instantiate(mcObjPrefab);
            mcObj.transform.position = pos;
            MagicCircle mc = mcObj.GetComponent<MagicCircle>();
            mc.OnCompleteAction = func;
            return mc;
        }
    }

}
