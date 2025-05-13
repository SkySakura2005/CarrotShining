
using Managers;
using Objects;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI.Main
{
    public class MainCommand:BaseCommand,PlayerInputControls.IMainUIActions
    {
        public Button phoneButton;

        public Vector2 moveInput;
        

        private void Start()
        {
            
        }
        public override void AddListeners()
        {
            _controls.MainUI.Enable();
            _controls.MainUI.SetCallbacks(this);
            phoneButton.onClick.AddListener(() => ContentManager.Instance.Push("Phone"));
            base.AddListeners();
        }

        public override void RemoveListeners()
        {
            phoneButton.onClick.RemoveAllListeners();
            _controls.MainUI.Disable();
            _controls.MainUI.SetCallbacks(null);
            base.RemoveListeners();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }
    }
}