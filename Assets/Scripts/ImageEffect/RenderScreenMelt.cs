using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[ExecuteInEditMode]
public class RenderScreenMelt : MonoBehaviour {
    [SerializeField]
    Shader curShader;
    Material curMaterial;
    Material mat
    {
        get
        {
            if (!curMaterial)
            {
                curMaterial = new Material(curShader);
            }
            return curMaterial;
        }
    }
    [Range(0,1)]
    public float melt = 0;
    [SerializeField]
    Texture MeltTex;
    [SerializeField]
    Texture EdgeTex;
    [SerializeField]
    Texture GameoverTex;
    private void Start()
    {
        mat.SetTexture("_MeltTex", MeltTex);
        mat.SetTexture("_MeltEdge",EdgeTex);
        if (melt == 1)
        {
            DOTween.To(() => melt, x => melt = x, 0, 1);
        }
    }

    public void SetGameoverTexture()
    {      
        mat.SetTexture("_ScreenMask", GameoverTex);
    }

    public void SetNullTexture()
    {
        mat.SetTexture("_ScreenMask", null);
    }

    private void Update()
    {
        mat.SetFloat("_Melt", melt);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (CheckEnable())
        {
            Graphics.Blit(source, destination, curMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    bool CheckEnable()
    {
        return SystemInfo.supportsImageEffects && curShader.isSupported;
    }

    public void StartMelt(float time)
    {
        melt = 0;
        DOTween.To(() => melt, x => melt = x, 1, time);
    }
}
