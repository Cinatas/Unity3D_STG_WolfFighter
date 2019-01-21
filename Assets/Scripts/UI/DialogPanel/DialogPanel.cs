using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WolfFighter.UI.Dialog;

namespace WolfFighter.UI
{
    public class DialogPanel : MonoBehaviour
    {
        public static DialogPanel _Instance = null;
        public DialogManager LeftDialogManager;
        public DialogManager RightDialogManager;
        private void Awake()
        {
            _Instance = this;
            LeftDialogManager = this.transform.Find("LeftDialog").GetComponent<DialogManager>();
            RightDialogManager = this.transform.Find("RightDialog").GetComponent<DialogManager>();
        }

        private void Start()
        {
            HideDialog(DialogType.LeftDialog);
            HideDialog(DialogType.RightDialog);
        }


        public void ShowDialog(DialogType dir,string picCode,string context)
        {
            switch (dir)
            {
                case DialogType.LeftDialog:
                    LeftDialogManager.ShowNpcPic(picCode);
                    LeftDialogManager.ShowText(context, 1);
                    break;
                case DialogType.RightDialog:
                    RightDialogManager.ShowNpcPic(picCode);
                    RightDialogManager.ShowText(context, 1);
                    break;
                default:
                    break;
            }
        }

        public void HideDialog(DialogType dir)
        {
            switch (dir)
            {
                case DialogType.LeftDialog:
                    LeftDialogManager.Hide();
                    break;
                case DialogType.RightDialog:
                    RightDialogManager.Hide();
                    break;
                default:
                    break;
            }
        }
    }

    public enum DialogType
    {
        LeftDialog,
        RightDialog
    }
}
