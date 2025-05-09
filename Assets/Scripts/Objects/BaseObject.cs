using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Objects
{
    public class BaseObject:MonoBehaviour
    {
        private SpriteRenderer sr;
        private Collider2D coll;
        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            coll = GetComponent<Collider2D>();
        }

        private void Update()
        {
            sr.sortingOrder = Mathf.RoundToInt(coll.bounds.center.y * -100);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if(Input.GetKeyDown(KeyCode.F)) OnEvent();
            }
        }

        private void OnMouseDown()
        {
            Debug.Log(gameObject.name+" OnMouseDown");
        }

        protected virtual void OnEvent(){}
        
    }
}