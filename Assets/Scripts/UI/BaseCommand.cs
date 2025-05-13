using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseCommand:MonoBehaviour
    {
        protected PlayerInputControls _controls;

        public bool available=false;
        private void Awake()
        {
            _controls = new PlayerInputControls();
        }

        public virtual void AddListeners()
        {
            available = true;
        }

        public virtual void RemoveListeners()
        {
            available = false;
        }
    }
}