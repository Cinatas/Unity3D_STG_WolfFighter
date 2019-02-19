using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Level1
{
    public class MedeaAngel : MonoBehaviour
    {
        public Vector3 Pos;

        public GameObject StageInFX;

        SpriteRenderer sp;

        [ContextMenu("Set Pos")]
        void SetPosition()
        {
            Pos = this.transform.position;
        }

        private void Awake()
        {
            sp = this.GetComponent<SpriteRenderer>();
            sp.enabled = false;
        }

        // Use this for initialization
        protected virtual IEnumerator Start()
        {
            if (StageInFX != null)
            {
                Instantiate(StageInFX).transform.position = this.transform.position;
            }
            yield return new WaitForSeconds(0.5f);
            sp.enabled = true;
        }

    }

}
