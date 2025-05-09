
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
        public Player player;

        private void Start()
        {
            player = GameObject.Find("Rabbit").GetComponent<Player>();
        }
        public override void AddListeners()
        {
            _controls.MainUI.Enable();
            _controls.MainUI.SetCallbacks(this);
            phoneButton.onClick.AddListener(() => ContentManager.Instance.Push("Phone"));
            
        }

        public override void RemoveListeners()
        {
            phoneButton.onClick.RemoveAllListeners();
            _controls.MainUI.Disable();
            _controls.MainUI.SetCallbacks(null);
            
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            player.moveInput = context.ReadValue<Vector2>();
        }
    }
}