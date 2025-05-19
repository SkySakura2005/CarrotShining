using Managers;
using UnityEngine.UI;

namespace UI.Profile
{
    public class ProfileCommand:BaseCommand
    {
        public Button exitButton;

        public override void AddListeners()
        {
            base.AddListeners();
            exitButton.onClick.AddListener((() =>
            {
                ContentManager.Instance.Pop(); 
                exitButton.gameObject.SetActive(false);
            }));
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}