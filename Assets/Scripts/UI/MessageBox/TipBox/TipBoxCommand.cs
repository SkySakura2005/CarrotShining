using System;
using Managers;
using UnityEngine.UI;

namespace UI.MessageBox.YesNoBox
{
    public class TipBoxCommand:BaseCommand
    {
        public Action Callback;
        public Button ConfirmButton;
        public override void AddListeners()
        {
            base.AddListeners();
            ConfirmButton.onClick.AddListener(() =>
            {
                ConfirmButton.enabled = false;
                ContentManager.Instance.Pop();
                Callback.Invoke();
            });
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            ConfirmButton.onClick.RemoveAllListeners();
        }
    }
}