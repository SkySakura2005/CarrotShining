using System;
using UnityEngine.InputSystem;

namespace UI.Dialog
{
    public class DialogCommand:BaseCommand,PlayerInputControls.IDialogUIActions
    {
        public bool anykeyIsDown;
        public override void AddListeners()
        {
            _controls.DialogUI.Enable();
            _controls.DialogUI.SetCallbacks(this);
            base.AddListeners();
        }

        public override void RemoveListeners()
        {
            _controls.DialogUI.Disable();
            _controls.DialogUI.SetCallbacks(null);
            base.RemoveListeners();
        }

        public void OnSkip(InputAction.CallbackContext context)
        {
            anykeyIsDown = context.performed;
        }
    }
}