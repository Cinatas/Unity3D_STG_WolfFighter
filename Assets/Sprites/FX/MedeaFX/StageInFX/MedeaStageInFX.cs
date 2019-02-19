using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WolfFighter.Level1;

namespace WolfFighter.FX
{
    public class MedeaStageInFX : MonoBehaviour
    {
        void OnAnimationCompleted()
        {
            Destroy(this.gameObject);
        }   
        
        void GenerateMedea()
        {
            if(BossMedea._Instance != null)
            {
                BossMedea._Instance.Show();
            }
        }
    }

}
