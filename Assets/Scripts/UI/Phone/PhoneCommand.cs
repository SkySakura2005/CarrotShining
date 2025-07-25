using Managers;
using Unity.Burst.Intrinsics;
using UnityEngine.UI;

namespace UI.Phone
{
    public class PhoneCommand:BaseCommand
    {
        public Button exitButton;
        public override void AddListeners()
        {
            base.AddListeners();
            exitButton.onClick.AddListener(() =>
            {
                ContentManager.Instance.Pop(); 
                exitButton.gameObject.SetActive(false);
            });
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            exitButton.onClick.RemoveAllListeners();
        }
    }
}