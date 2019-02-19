using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    public class ParticleAutoDestruction : MonoBehaviour
    {
        private ParticleSystem particleSystem;

        private void Awake()
        {
            particleSystem = this.GetComponent<ParticleSystem>();
        }

        private void Start()
        {
            Destroy(this.gameObject,particleSystem.main.duration);
        }
    }

}
