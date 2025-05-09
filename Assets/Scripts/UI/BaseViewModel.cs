using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseViewModel:MonoBehaviour
    {
        
        private void Update()
        {
            ProcessString();
            UpdateView();
            UpdateModel();
        }
        protected abstract void ProcessString();
        protected abstract void UpdateView();
        protected abstract void UpdateModel();
    }
}