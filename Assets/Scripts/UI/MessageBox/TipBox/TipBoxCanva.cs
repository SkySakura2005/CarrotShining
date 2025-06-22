using System.Collections;
using UnityEngine;

namespace UI.MessageBox.YesNoBox
{
    public class TipBoxCanva:BaseUICanvas
    {
        public GameObject window;
        public override IEnumerator OnUIEnter()
        {
            RectTransform rectTransform = window.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0,-200);
            float transition = 0;
            while (transition < 1)
            {
                rectTransform.anchoredPosition=Vector2.Lerp(new Vector2(0,-200),new Vector2(0,0),transition);
                window.GetComponent<CanvasGroup>().alpha = transition;
                transition += Time.deltaTime*2;
                yield return null;
            }
            StartCoroutine(base.OnUIEnter());
        }

        public override IEnumerator OnUIExit()
        {
            RectTransform rectTransform = window.GetComponent<RectTransform>();
            float transition = 0;
            while (transition < 1)
            {
                rectTransform.anchoredPosition=Vector2.Lerp(new Vector2(0,0),new Vector2(0,-200),transition);
                window.GetComponent<CanvasGroup>().alpha =1-transition;
                transition += Time.deltaTime*2;
                yield return null;
            }
            StartCoroutine(base.OnUIExit());
        }
    }
}