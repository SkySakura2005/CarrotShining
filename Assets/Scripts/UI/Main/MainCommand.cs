
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
        public Button profileButton;
        public Vector2 moveInput;
        

        private void Start()
        {
            
        }
        public override void AddListeners()
        {
            _controls.MainUI.Enable();
            _controls.MainUI.SetCallbacks(this);
            phoneButton.onClick.AddListener(() => ContentManager.Instance.Push("Phone"));
            profileButton.onClick.AddListener(() => ContentManager.Instance.Push("Profile"));
            base.AddListeners();
        }

        public override void RemoveListeners()
        {
            phoneButton.onClick.RemoveAllListeners();
            profileButton.onClick.RemoveAllListeners();
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