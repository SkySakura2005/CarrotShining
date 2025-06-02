using UnityEngine;
using UnityEngine.UIElements;

namespace UI.Phone.Pages
{
    public class MainPage:BasePage
    {
        public GameObject[] buttons;
        public GameObject[] pages;
        protected override void InitializeButtonReceivers()
        {
            foreach (var button in buttons)
            {
                buttonReceivers.Add(new ButtonReceiver(button,"phoneMainPage/"+button.name+"Page"));
            }
        }

        protected override void OnEnableButtonReceivers()
        {
            for(int i=0; i<buttonReceivers.Count; i++)
            {
                
                int index = i;
                buttonReceivers[i].AddListener(() =>
                {
                    pages[index].SetActive(true);
                });
                
            }
        }

        protected override void OnDisableOtherButtons()
        {
            
        }
    }
}