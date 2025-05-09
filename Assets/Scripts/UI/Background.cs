using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CarrotWinkWink
{
    public class Background : MonoBehaviour
    {
        public Vector3 startPos;
        public Vector3 endPos;

        public float speed = 0.8f;
        
        private Vector3 dic;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = startPos;
            dic = (endPos - startPos).normalized;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = transform.position + dic*Time.deltaTime*speed;
            if ((transform.position - endPos).magnitude < 0.1f)
            {
                transform.position = startPos;
            }
        }
    }
}

