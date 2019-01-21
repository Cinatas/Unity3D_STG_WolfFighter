using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
namespace WolfFighter.Level1
{
    public class Wave10 : MonoBehaviour
    {
        EnemySlime[] slimes;
        bool shootSwitch = false;
        float rotateSpeed = 30;
        private void Awake()
        {
            slimes = this.GetComponentsInChildren<EnemySlime>();
        }

        // Use this for initialization
        void Start()
        {
            
            this.transform.DOScale(0.15f, 7).SetEase(Ease.Linear).OnComplete(() =>
            {
                shootSwitch = true;
            });
            StartCoroutine(Shoot(1));
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            this.transform.localEulerAngles = new Vector3(1, 1, Time.time * rotateSpeed);
        }

        IEnumerator Shoot(float delay)
        {
            while (true)
            {
                if (!shootSwitch)
                {
                    yield return new WaitForSeconds(delay);
                    if (Player.Player._Instance != null)
                    {
                        foreach (var i in slimes)
                        {
                            if(i!=null)
                            i.Shoot(Player.Player._Instance.transform.position);
                        }
                    }
                }
                else
                {
                    yield return new WaitForSeconds(0.15f);
                    foreach (var i in slimes)
                    {
                        if (i != null)
                        {
                            Vector3 dir = Vector3.Normalize(i.transform.position - this.transform.position);
                            i.Shoot(dir);
                        }
                            
                    }
                }
            }            
        }
    }

}
