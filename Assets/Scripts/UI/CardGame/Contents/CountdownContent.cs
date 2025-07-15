using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.CardGame.Contents
{
    public class CountdownContent:MonoBehaviour
    {
        public float MaxCountdownTime => 10f;
        public float currentCountdownTime;
        
        private bool _isCountingDown;

        public Text countdownText;
        public Image warningImage;

        public Action[] CountdownAction;
        
        private Coroutine countdownCoroutine;
        private void Awake()
        {
            _isCountingDown = false;
            currentCountdownTime = MaxCountdownTime;
            countdownCoroutine = null;
            CountdownAction = new Action[(int)MaxCountdownTime+1];
            for (int i = 0; i < CountdownAction.Length; i++)
            {
                int temp = i;
                if (i > 0 && i <= 3)
                {
                    CountdownAction[i] += () =>
                    {
                        StartCoroutine(WarningImageCoroutine());
                    };
                }
                CountdownAction[i] += () =>
                {
                    Debug.Log("Countdown: "+temp+" in Time: "+currentCountdownTime);
                };
            }
        }

        private void Update()
        {
            countdownText.text = ((int)currentCountdownTime).ToString();
        }

        private IEnumerator CountdownCoroutine()
        {
            _isCountingDown = true;
            float tmpTime = currentCountdownTime;
            while (currentCountdownTime > 0)
            {
                currentCountdownTime -= Time.deltaTime;
                if ((int)tmpTime != (int)currentCountdownTime)
                {
                    CountdownAction[(int)tmpTime]?.Invoke();
                }
                tmpTime = currentCountdownTime;
                yield return null;
            }
            CountdownAction[0].Invoke();
            currentCountdownTime = MaxCountdownTime;
            _isCountingDown = false;
        }

        public void StartCountdown()
        {
            if(_isCountingDown)
            {
                Debug.LogWarning("The countdown is still running. The request will be ignored.");
                return;
            }
            countdownCoroutine=StartCoroutine(CountdownCoroutine());
        }

        public void StopCountdown()
        {
            if(_isCountingDown)
            {
                StopCoroutine(CountdownCoroutine());
            }
            currentCountdownTime=MaxCountdownTime;
            _isCountingDown = false;
        }

        public void UpdateTime(float seconds)
        {
            if (_isCountingDown)
            {
                currentCountdownTime += seconds;
            }
        }

        private IEnumerator WarningImageCoroutine()
        {
            float alpha = 0;
            while (alpha < 0.5)
            {
                alpha += Time.deltaTime;
                warningImage.color = new Color(1f, 0f, 0f, alpha);
                yield return null;
            }
            warningImage.color = new Color(1f, 0f, 0f, 0f);
        }
    }
}