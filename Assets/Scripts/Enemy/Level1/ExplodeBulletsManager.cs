using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Utility;

namespace WolfFighter.Level1
{
    public class ExplodeBulletsManager : MonoBehaviour
    {
        public static ExplodeBulletsManager _Instance = null;
        public GameObject[] ExplodeBulletPrefabs;
        private void Awake()
        {
            _Instance = this;
        }

        public ExplodeBullets GenerateExplodeBullet(int type)
        {
            if (ExplodeBulletPrefabs.Length <= type || type<0)
                return null;
            GameObject obj = Instantiate(ExplodeBulletPrefabs[type - 1]);
            ExplodeBullets bullet = obj.GetComponent<ExplodeBullets>();
            bullet.transform.localScale = new Vector3(0.1f, 0.1f, 1);
            return bullet;
        }
    }

}
