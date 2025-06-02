using UnityEngine.UI;

namespace UI.Phone.Pages
{
    public class MessagePage:BasePage
    {
        public Button backButton;
        protected override void InitializeButtonReceivers()
        {
            
        }

        protected override void OnEnableButtonReceivers()
        {
            backButton.onClick.AddListener(() => {gameObject.SetActive(false);});
        }

        protected override void OnDisableOtherButtons()
        {
            backButton.onClick.RemoveAllListeners();
        }
    }
}