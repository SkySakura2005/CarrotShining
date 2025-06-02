using System;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Phone.Pages
{
    public class ButtonReceiver
    {
        private GameObject _button;
        private MessageNode _node;
        
        public ButtonReceiver(GameObject button, string path)
        {
            
            if (button.GetComponent<Button>() == null || button.transform.Find("RedDot") == null)
            {
                Debug.LogError("The button "+path+" is not illegal!");
            }
            _button = button;
            _node=MessageManager.Instance.GetNode(path);
        }

        public void UpdateView()
        {
            if (_node.MessageNum > 0&& !_button.transform.Find("RedDot").gameObject.activeSelf)
            {
                _button.transform.Find("RedDot").gameObject.SetActive(true);
            }
            else if(_node.MessageNum == 0&&_button.transform.Find("RedDot").gameObject.activeSelf)
            {
                _button.transform.Find("RedDot").gameObject.SetActive(false);
            }
        }

        public void AddListener(UnityAction callback)
        {
            _button.GetComponent<Button>().onClick.AddListener(callback);
            _button.GetComponent<Button>().onClick.AddListener(_node.ReadMessage);
        }

        public void RemoveListener()
        {
            _button.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        /*public string GetName(){
            return _name;
        }*/
    }
    public abstract class BasePage:MonoBehaviour
    {
        public List<ButtonReceiver> buttonReceivers;
        

        private void Awake()
        {
            buttonReceivers = new List<ButtonReceiver>();
            InitializeButtonReceivers();
        }
        
        protected abstract void InitializeButtonReceivers();
        private void OnEnable()
        {
            OnEnableButtonReceivers();
        }
        protected abstract void OnEnableButtonReceivers();
        private void OnDisable()
        {
            foreach (var receiver in buttonReceivers)
            {
                receiver.RemoveListener();
            }
        }
        protected abstract void OnDisableOtherButtons();
        private void Update()
        {
            foreach (var receiver in buttonReceivers)
            {
                receiver.UpdateView();
            }
        }
    }
}