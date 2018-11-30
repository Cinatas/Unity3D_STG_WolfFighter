using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.Utility
{
    [ExecuteInEditMode]
    public class BackCameraRenderImage : MonoBehaviour
    {

        public Shader curShader;
        public float grayScaleAmount = 1;
        public Color color;
        private Material curMaterial;
        Material material
        {
            get
            {
                if (curMaterial == null)
                {
                    curMaterial = new Material(curShader);
                    curMaterial.hideFlags = HideFlags.HideAndDontSave;
                }
                return curMaterial;
            }
        }

        // Use this for initialization
        void Start()
        {
            if (!SystemInfo.supportsImageEffects)
            {
                this.enabled = false;
                return;
            }

            if (!curShader && !curShader.isSupported)
                this.enabled = false;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (curShader != null)
            {
                material.SetFloat("_LuminosityAmount", grayScaleAmount);
                material.SetColor("_MainColor", color);
                Graphics.Blit(source, destination,material);
            }
        }

        private void Update()
        {
            grayScaleAmount = Mathf.Clamp(grayScaleAmount,-1,1f);            
        }

        private void OnDisable()
        {
            if (curMaterial)
            {
                DestroyImmediate(curMaterial);
            }
        }
    }

}
