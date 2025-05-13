using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarUICanva:BaseUICanvas
    {
        public Image backgroundImage;
        public override IEnumerator OnUIEnter()
        {
            backgroundImage.color=new Color(1,1,1,0);
            float alpha = backgroundImage.color.a;
            while (alpha<0.4)
            {
                alpha += Time.deltaTime;
                backgroundImage.color=new Color(1,1,1,alpha);
                yield return null;
            }
            StartCoroutine(base.OnUIEnter());
        }

        public override IEnumerator OnUIExit()
        {
            Debug.Log("Son OnUIExit is entering");
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