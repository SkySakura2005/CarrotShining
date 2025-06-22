using System;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UI.MessageBox.YesNoBox;

namespace Managers
{
    public class ContentManager:MonoBehaviour
    {
        private Action _currentAction;
        private Stack<GameObject> _contentStack = new Stack<GameObject>();

        public static ContentManager Instance;

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

        private void Update()
        {
            _currentAction?.Invoke();
        }
        
        public void Push(string contentName,params string[] args)
        {
            if (_contentStack.Count != 0)
            {
                StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIOpen());
            }
            GameObject prefab=Instantiate(Resources.Load<GameObject>("Prefabs/"+contentName));
            ErrorProcess(prefab);
            prefab.name = contentName;
            _contentStack.Push(prefab);
            StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIEnter());
            _contentStack.Peek().GetComponent<BaseViewModel>().args = args;
        }

        public void Pop()
        {
            Debug.Log("Poping the content"+_contentStack.Peek());
            
            StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIExit());
            _contentStack.Pop();
            if (_contentStack.Count != 0)
            {
                StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIReturn());
                
            }
            else
            {
                Debug.Log("ContentStack is empty!!! And check if there is any error!");
            }
        }

        public void PushMessageBox(string messageText,Action yesCallback,Action noCallback)
        {
            if (_contentStack.Count != 0)
            {
                StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIOpen());
            }
            GameObject prefab=Instantiate(Resources.Load<GameObject>("Prefabs/MessageBox/YesNoBox"));
            ErrorProcess(prefab);
            prefab.name = "YesNoMessageBox";
            _contentStack.Push(prefab);
            _contentStack.Peek().GetComponent<YesNoBoxViewModel>().MessageText = messageText;
            _contentStack.Peek().GetComponent<YesNoBoxCommand>().YesCallback = yesCallback;
            _contentStack.Peek().GetComponent<YesNoBoxCommand>().NoCallback = noCallback;
            StartCoroutine(_contentStack.Peek().GetComponent<BaseUICanvas>().OnUIEnter());
        }
        private void ErrorProcess(GameObject prefab)
        {
            if (prefab == null)
            {
                Debug.LogError("Can't load "+prefab.name+"because it is null!!!");
            }
            else if(prefab.GetComponent<BaseUICanvas>()==null)
            {
                Debug.LogError("BaseUICanvas in"+prefab.name+" doesn't exist!!!");
            }
        }
    }
}