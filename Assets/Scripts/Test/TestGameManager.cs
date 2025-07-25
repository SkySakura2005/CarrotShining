using Managers;
using UnityEngine;

namespace Test
{
    public class TestGameManager:MonoBehaviour
    {
        public static TestGameManager instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            DontDestroyOnLoad(this);
            ContentManager.Instance.Push("Main");
        }
    }
}