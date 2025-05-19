using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Profile
{
    public class ProfileUICanva:BaseUICanvas
    {
        public Image backgroundImage;
        public GameObject profile;
        public override IEnumerator OnUIEnter()
        {
            RectTransform rectTransform = profile.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0,-1100);
            backgroundImage.color=new Color(1,1,1,0);
            float alpha = backgroundImage.color.a;
            while (alpha<0.4)
            {
                alpha += Time.deltaTime;
                backgroundImage.color=new Color(1,1,1,alpha);
                yield return null;
            }

            float transition = 0;
            while (transition < 1)
            {
                rectTransform.anchoredPosition=Vector2.Lerp(new Vector2(0,-1100),new Vector2(0,0),transition);
                transition += Time.deltaTime*4;
                yield return null;
            }
            
            rectTransform.anchoredPosition=new Vector2(0,0);
            StartCoroutine(base.OnUIEnter());
        }

        public override IEnumerator OnUIExit()
        {
            RectTransform rectTransform = profile.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(0,0);
            float transition = 0;
            while (transition < 1)
            {
                rectTransform.anchoredPosition=Vector2.Lerp(new Vector2(0,0),new Vector2(0,-1100),transition);
                transition += Time.deltaTime*4;
                yield return null;
            }
            
            rectTransform.anchoredPosition=new Vector2(0,-1100);
            float alpha = backgroundImage.color.a;
            while (alpha>0)
            {
                alpha -= Time.deltaTime;
                backgroundImage.color=new Color(1,1,1,alpha);
                yield return null;
            }
            
            StartCoroutine(base.OnUIExit());
        }
    }
}