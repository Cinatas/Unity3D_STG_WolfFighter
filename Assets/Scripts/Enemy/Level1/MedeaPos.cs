using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class MedeaPos : MonoBehaviour
    {
        Transform[] poses;

        private void Awake()
        {
            poses = this.transform.GetComponentsInChildren<Transform>();
        }

        // Use this for initialization
        void Start()
        {
            BossMedea._Instance.PosManager = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public Vector3 GetNextPosition()
        {
            int randomIndex = Random.Range(0, poses.Length);

            return poses[randomIndex].position;
        }

        public Vector3 GetTopMiddlePosition()
        {
            return new Vector3(0, 3, 0);
        }

        public Vector3 GetCurrentPosition()
        {
            return BossMedea._Instance.transform.position;
        }

        public Vector3 GetAroundPosition()
        {
            Vector3 medeaPos = BossMedea._Instance.transform.position;

            return medeaPos + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        }

        public Vector3 GetAroundPosition(float distance)
        {
            Vector3 medeaPos = BossMedea._Instance.transform.position;

            return medeaPos + new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), 0);
        }

        public Vector3 GetLeftTopPos()
        {
            Transform pos = this.transform.Find("LeftTopPos");
            return pos.position;
        }

        public Vector3 GetRightTopPos()
        {
            Transform pos = this.transform.Find("RightTopPos");
            return pos.position;
        }

        public Vector3 GetTopCenterPos()
        {
            Transform pos = this.transform.Find("TopCenter");
            return pos.position;
        }

        public Vector3 GetCenterArea(float distance)
        {
            return GetCenterPos() + new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), 0);
        }

        public Vector3 GetCenterPos()
        {
            Transform pos = this.transform.Find("Center");
            return pos.position;
        }
    }

}
