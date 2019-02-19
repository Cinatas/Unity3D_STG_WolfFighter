using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WolfFighter.UI.Dialog
{
    public class NpcFrame : MonoBehaviour
    {
        public Image npcImg;

        private void Awake()
        {
            npcImg = this.GetComponentInChildren<Image>();
        }

        public void ChangePic(string PicCodeName)
        {
            if (PicCodeName == "")
            {
                npcImg.sprite = null;
                npcImg.enabled = false;
            }
            else
            {
                Texture2D npcPic;
                ResourceManager._Instance.textureResources.TryGetValue(PicCodeName, out npcPic);

                if (npcPic == null)
                {
                    ChangePic("");
                    return;
                }
                else
                {
                    Sprite npcPicSprite = Sprite.Create(npcPic, new Rect(0, 0, npcPic.width, npcPic.height), new Vector2(0.5f, 0.5f));
                    npcImg.sprite = npcPicSprite;
                    npcImg.enabled = true;
                    npcImg.SetNativeSize();
                } 
            }
        }
    }

}
