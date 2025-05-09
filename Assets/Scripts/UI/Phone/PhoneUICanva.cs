using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Phone
{
    public class PhoneUICanva:BaseUICanvas
    {
        public Image backgroundImage;
        public GameObject phone;
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
            Debug.Log("Son OnUIEnter is entering");
            StartCoroutine(base.OnUIEnter());
        }

        public override IEnumerator OnUIExit()
        {
            float alpha = backgroundImage.color.a;
            while (alpha>0)
            {
                alpha -= Time.deltaTime;
                backgroundImage.color=new Color(1,1,1,alpha);
                yield return null;
            }
            Debug.Log("Son OnUIExit is entering");
            StartCoroutine(base.OnUIExit());
        }
    }
}