using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace WolfFighter.UI.Dialog
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
    }
}
