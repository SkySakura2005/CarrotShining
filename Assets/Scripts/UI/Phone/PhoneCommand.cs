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
            exitButton.onClick.AddListener(() => { ContentManager.Instance.Pop(); });
        }

        public override void RemoveListeners()
        {
            exitButton.onClick.RemoveAllListeners();
        }
    }
}