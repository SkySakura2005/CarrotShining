using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Objects.InteractButtons
{
    public class InteractButton:MonoBehaviour
    {
        //public Action<PointerEventData> onClick;

        private void OnMouseDown()
        {
            Debug.Log("OnMouseDown");
        }

        
        
    }
}