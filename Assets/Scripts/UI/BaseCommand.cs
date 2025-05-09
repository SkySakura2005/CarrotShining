using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseCommand:MonoBehaviour
    {
        protected PlayerInputControls _controls;

        private void Awake()
        {
            _controls = new PlayerInputControls();
        }

        public abstract void AddListeners();
        public abstract void RemoveListeners();
    }
}