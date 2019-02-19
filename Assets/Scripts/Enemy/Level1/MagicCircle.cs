using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

namespace WolfFighter.Level1
{
    public class MagicCircle : MonoBehaviour
    {
        public UnityAction OnCompleteAction;
        SpriteRenderer sp;
        public GameObject waveFX;

        private void Awake()
        {
            sp = this.GetComponent<SpriteRenderer>();
            Hide();
        }

        // Use this for initialization
        IEnumerator Start()
        {
            sp.DOFade(1, 0.5f);
            yield return new WaitForSeconds(0.5f);
            Show();
        }

        void Hide()
        {
            sp.color = new Color(1, 1, 1, 0);
            this.transform.localScale = new Vector3(2, 2, 2);
            this.transform.localEulerAngles = Vector3.zero;
        }

        void Show()
        {    
            this.transform.DOScale(0.5f, 1);
            this.transform.DORotate(new Vector3(0, 0, 180), 1).OnComplete(()=>
            {
                Instantiate(waveFX).transform.position = this.transform.position;
                Hide();
                if (OnCompleteAction != null)
                {
                    OnCompleteAction();
                }
            });
        }
    }

}
