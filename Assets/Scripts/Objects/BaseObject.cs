using System;
using UI.Main;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Objects
{
    public class BaseObject:MonoBehaviour
    {
        private MainCommand _command;
        private bool _onPlayerMovein;
        private Vector2 _spriteSize;
        
        private SpriteRenderer sr;
        private Collider2D coll;
        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
            coll = GetComponent<Collider2D>();
            _command = GameObject.Find("Main").GetComponent<MainCommand>();
            //_spriteSize = sr.sprite.bounds.size;
        }

        private void Update()
        {
            sr.sortingOrder = Mathf.RoundToInt(coll.bounds.center.y * -100);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                /*if (transform.Find("Pointer") != null)
                {
                    transform.Find("Pointer").gameObject.SetActive(true);
                }*/
                _onPlayerMovein = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                /*if (transform.Find("Pointer") != null)
                {
                    transform.Find("Pointer").gameObject.SetActive(false);
                }*/
                _onPlayerMovein = false;
            }
        }

        /*private void OnMouseEnter()
        {
            if (_command.available && _onPlayerMovein)
            {
                Bounds bounds = sr.sprite.bounds;
                bounds.size=new Vector2(_spriteSize.x*1.2f,_spriteSize.y*1.2f);
            }
        }

        private void OnMouseExit()
        {
            if (_command.available)
            {
                Bounds bounds = sr.sprite.bounds;
                bounds.size=new Vector2(_spriteSize.x,_spriteSize.y);
            }
        }*/

        private void OnMouseDown()
        {
            
            if (_command.available && _onPlayerMovein)
            {
                Debug.Log(gameObject.name+" OnMouseDown");
                OnEvent();
            }
        }

        protected virtual void OnEvent(){}
        
    }
}