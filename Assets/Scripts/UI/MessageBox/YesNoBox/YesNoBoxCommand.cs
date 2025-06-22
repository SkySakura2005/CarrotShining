using System;
using Managers;
using UnityEngine.UI;

namespace UI.MessageBox.YesNoBox
{
    public class YesNoBoxCommand:BaseCommand
    {
        public Action YesCallback;
        public Action NoCallback;
        public Button YesButton;
        public Button NoButton;
        public override void AddListeners()
        {
            base.AddListeners();
            YesButton.onClick.AddListener(() =>
            {
                YesButton.enabled = false;
                NoButton.enabled = false;
                ContentManager.Instance.Pop();
                YesCallback.Invoke();
            });
            NoButton.onClick.AddListener(() =>
            {
                YesButton.enabled = false;
                NoButton.enabled = false;
                ContentManager.Instance.Pop();
                NoCallback.Invoke();
            });
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            YesButton.onClick.RemoveAllListeners();
            NoButton.onClick.RemoveAllListeners();
        }
    }
}