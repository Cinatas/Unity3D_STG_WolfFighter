using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class MedeaPos : MonoBehaviour
    {
        public static MedeaPos _Instance = null;
        Transform[] poses;

        private void Awake()
        {
            _Instance = this;
            poses = this.transform.GetComponentsInChildren<Transform>();
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

        public Vector3 GetRightPos()
        {
            Transform pos = this.transform.Find("RightPos");
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

        public Vector3 GetExitPos()
        {
            Transform pos = this.transform.Find("ExitPos");
            return pos.position;
        }
    }

}
