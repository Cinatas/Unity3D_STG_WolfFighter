using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class TriBulletsManager : MonoBehaviour
    {
        public static TriBulletsManager _Instance = null;
        public GameObject triPrefab;

        private void Awake()
        {
            _Instance = this;
        }

        private void Start()
        {

        }

        public void LaunchTriBullet(Vector3 pos,float angle)
        {
            TriBullets tri = Instantiate(triPrefab).GetComponent<TriBullets>();
            tri.transform.position = pos;
            tri.angle = angle;
        }
    }

}
