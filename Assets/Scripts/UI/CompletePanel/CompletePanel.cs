using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace WolfFighter.UI
{
    public class CompletePanel : MonoBehaviour
    {
        public GameObject completeTitle;
        public GameObject gameoverTitle;

        public void ShowCompleteImage()
        {
            completeTitle.SetActive(true);
            Image img = completeTitle.GetComponent<Image>();
            img.DOFade(1, 1);
        }

        public void HideCompleteImage()
        {
            completeTitle.SetActive(false);
        }

        public void ShowGameoverImage()
        {
            gameoverTitle.SetActive(true);
        }       

        public void HideGameoverImage()
        {
            gameoverTitle.SetActive(false);
        }
    }

}
