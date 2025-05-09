using System.Collections;
using Managers;
using Objects;
using Unity.VisualScripting;
using UnityEngine.UI;

namespace UI
{
    public class MainUICanva:BaseUICanvas
    {

        public override IEnumerator OnUIEnter()
        {
            StartCoroutine(base.OnUIEnter());
            yield return null;
        }
        
        public override IEnumerator OnUIExit()
        {
            StartCoroutine(base.OnUIExit());
            yield return null;
        }
    }
}