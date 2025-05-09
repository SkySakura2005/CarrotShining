using System;
using System.Collections;
using UnityEngine;

namespace UI
{
    public abstract class BaseUICanvas:MonoBehaviour
    {
        public BaseCommand _command;
        
        private void Awake()
        {
            _command = GetComponent<BaseCommand>();
            onErrorInvoke();
            Debug.Log(gameObject.name+"is created");
        }
        
        public virtual IEnumerator OnUIEnter()
        {
            //UI的进入动画写在这里，并含有按钮监听的注册
            Debug.Log("Base OnUIEnter is entering");
            _command.AddListeners();
            yield break;
        }

        public virtual IEnumerator OnUIReturn()
        {
            
            //UI回到上级界面的效果写在这里，并含有按钮监听的注册
            _command.AddListeners();
            yield break;
        }

        public virtual IEnumerator OnUIOpen()
        {
            _command.RemoveListeners();
            yield return null;
            //UI进入下级页面的动画写在这里，并含有按钮监听的注销
        }
        public virtual IEnumerator OnUIExit()
        {
            
            Debug.Log("Base OnUIExit is entering");
            //UI离开的动画写在这里，并含有按钮监听的注销与物体的销毁
            _command.RemoveListeners();
            Destroy(gameObject);
            yield return null;
        }

        private void onErrorInvoke()
        {
            if (_command == null)
            {
                Debug.LogError("BaseCommand is not exist!");
            }
        }
    }
}