using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Base;
using DG.Tweening;

namespace WolfFighter.Level1
{
    public class Wave1 : EnemyWave
    {
        IEnumerator Start()
        {
            yield return new WaitForSeconds(3);
            this.transform.DOMoveY(-20, 10).SetEase(Ease.Linear).onComplete += () =>
            {
                Destroy(this.gameObject);
            };
        }

    }

}
