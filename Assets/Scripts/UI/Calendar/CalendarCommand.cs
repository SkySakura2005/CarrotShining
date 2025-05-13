using System;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarCommand:BaseCommand
    {
        public Button[] SelectButtons=new Button[4];
        public Button exitButton;

        private CalendarViewModel _viewModel;

        private void Start()
        {
            _viewModel=GetComponent<CalendarViewModel>();
            SelectButtons[_viewModel.mActiveSelection].interactable = false;
        }

        public override void AddListeners()
        {
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                SelectButtons[i].onClick.AddListener(()=>
                {
                    OnIconButtonClick(index);
                });
            }
            exitButton.onClick.AddListener(() =>
            {
                exitButton.enabled = false;
                ContentManager.Instance.Pop();
            });
        }

        public override void RemoveListeners()
        {
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                SelectButtons[i].onClick.RemoveAllListeners();
            }
            exitButton.onClick.RemoveAllListeners();
        }

        private void OnIconButtonClick(int index)
        {
            _viewModel.mActiveSelection = index;
            for (int i = 0; i < 4; i++)
            {
                SelectButtons[i].interactable = true;
                if (i == index)
                {
                    SelectButtons[i].interactable = false;
                }
            }
        }
    }
}