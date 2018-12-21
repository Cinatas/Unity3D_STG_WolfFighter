using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WolfFighter.UI.PlayerInfo
{
    public class Skill : MonoBehaviour
    {
        public Sprite icon;
        public float cdTime;
        public string iconCodeName;
        protected Texture2D iconTex;
        public UnityAction skillFunc;
        protected virtual void Awake()
        {
            iconTex = Resources.Load<Texture2D>("Texture/SkillIcon/" + iconCodeName);
            icon = Sprite.Create(iconTex, new Rect(0, 0, iconTex.width, iconTex.height), new Vector2(0.5f, 0.5f));
        }

        public virtual void CastSkill()
        {
            if (skillFunc != null)
            {
                skillFunc();
            }
            
        }
    }
}
