using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Objects
{
    public class Player:MonoBehaviour
    {
        public float speed;
        public Sprite[] dirSprites=new Sprite[4];
        public Vector2 moveInput;
        
        private SpriteRenderer _sr;
        private Collider2D _coll;
        private Rigidbody2D _rb;
        
        private void Start()
        {
            _sr=GetComponent<SpriteRenderer>();
            _coll=GetComponent<Collider2D>();
            _rb=GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _sr.sortingOrder = Mathf.RoundToInt(_coll.bounds.center.y * -100);
            PlayerMovement();
        }

        public void PlayerMovement()
        {
            Vector3 horiMove=new Vector3(moveInput.x*speed,moveInput.x*speed*0.6f);
            Vector3 vertMove=new Vector3(-moveInput.y*speed,moveInput.y*speed*0.6f);
            UpdateView(horiMove.x+vertMove.x,horiMove.y+vertMove.y);
            _rb.velocity=horiMove+vertMove;
        }

        private void UpdateView(float x, float y)
        {
            if (x > 0 && y > 0)
            {
                _sr.sprite = dirSprites[0];
            }
            else if (x > 0 && y < 0)
            {
                _sr.sprite = dirSprites[1];
            }
            else if (x < 0 && y > 0)
            {
                _sr.sprite = dirSprites[2];
            }
            else if (x < 0 && y < 0)
            {
                _sr.sprite = dirSprites[3];
            }
        }
    }
}