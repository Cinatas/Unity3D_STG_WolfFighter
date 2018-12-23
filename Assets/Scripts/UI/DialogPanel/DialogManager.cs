﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WolfFighter.UI.Dialog
{
    public class DialogManager : MonoBehaviour
    {        
        NpcFrame npc;
        DialogBubbleFrame bubble;

        private void Awake()
        {
            npc = this.GetComponentInChildren<NpcFrame>();
            bubble = this.GetComponentInChildren<DialogBubbleFrame>();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowText(string talkStr , float duration)
        {
            bubble.ChangeText(talkStr, duration);
        }

        public void ShowNpcPic(string npcPicCode)
        {
            npc.ChangePic(npcPicCode);
        }

        public void ShutdownAll()
        {

        }
    }

}