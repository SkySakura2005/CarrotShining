using System.Collections;

namespace UI.Dialog
{
    public class DialogCanva:BaseUICanvas
    {
        public override IEnumerator OnUIEnter()
        {
            yield return null;
            StartCoroutine(base.OnUIEnter());
            
        }
        
        public override IEnumerator OnUIExit()
        {
            yield return null;
            StartCoroutine(base.OnUIExit());
            
        }
    }
}