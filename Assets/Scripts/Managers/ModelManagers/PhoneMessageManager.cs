using System;
using UnityEngine;

namespace Managers
{
    public class PhoneMessageManager:MonoBehaviour
    {
        public static PhoneMessageManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
    }
}