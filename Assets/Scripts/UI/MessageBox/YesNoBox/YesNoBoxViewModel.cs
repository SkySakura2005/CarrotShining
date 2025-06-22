using UnityEngine.UI;

namespace UI.MessageBox.YesNoBox
{
    public class YesNoBoxViewModel:BaseViewModel
    {
        public string MessageText;
        public Text Message;
        protected override void Initialize()
        {
            Message.text = MessageText;
        }

        protected override void ProcessString()
        {
            
        }

        protected override void UpdateView()
        {
            
        }

        protected override void UpdateModel()
        {
            
        }
    }
}