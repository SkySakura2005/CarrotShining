using System;
using UnityEngine;

namespace Managers
{
    public class GeneralGameManager:MonoBehaviour
    {
        public static GeneralGameManager Instance;
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
            DontDestroyOnLoad(gameObject);
            ContentManager.Instance.Push("Main");
            ContentManager.Instance.Push("CardGame");
        }
    }
}