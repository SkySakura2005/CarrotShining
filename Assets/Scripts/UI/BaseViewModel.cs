using System;
using UnityEngine;

namespace UI
{
    public abstract class BaseViewModel:MonoBehaviour
    {
        public string[] args;
        private void Start()
        {
            Initialize();
            ProcessString();
        }

        private void Update()
        {
            UpdateModel();
            UpdateView();
            ProcessString();
        }

        protected abstract void Initialize();
        protected abstract void ProcessString();
        protected abstract void UpdateView();
        protected abstract void UpdateModel();
    }
}