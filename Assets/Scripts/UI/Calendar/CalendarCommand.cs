using System;
using cfg.schedule;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarCommand:BaseCommand
    {
        public Button[] SelectButtons=new Button[4];
        public Button[] ScheduleButtons=new Button[5];
        public Button exitButton;
        public Button pgLeftButton;
        public Button pgRightButton;

        private CalendarViewModel _viewModel;

        private void Start()
        {
            _viewModel=GetComponent<CalendarViewModel>();
            SelectButtons[_viewModel.mActiveSelection].interactable = false;
        }

        public override void AddListeners()
        {
            base.AddListeners();
            for (int i = 0; i < 4; i++)
            {
                int index = i;
                SelectButtons[i].onClick.AddListener(()=>
                {
                    OnIconButtonClick(index);
                });
            }

            for (int i = 0; i < 5; i++)
            {
                int index = i;
                ScheduleButtons[i].onClick.AddListener(() =>
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (_viewModel.mCardSchedules[j] == null)
                        {
                            _viewModel.mCardSchedules[j]=_viewModel.currentDateCards[index];
                            break;
                        }
                    }
                    
                });
            }
            exitButton.onClick.AddListener(() =>
            {
                exitButton.gameObject.SetActive(false);
                ContentManager.Instance.Pop();
            });
            pgLeftButton.onClick.AddListener(() =>
            {
                if(_viewModel.currentIndex[_viewModel.mActiveSelection]>0)_viewModel.currentIndex[_viewModel.mActiveSelection]--;
            });
            pgRightButton.onClick.AddListener(() =>
            {
                _viewModel.currentIndex[_viewModel.mActiveSelection]++;
            });
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            for (int i = 0; i < 4; i++)
            {
                SelectButtons[i].onClick.RemoveAllListeners();
            }

            for (int i = 0; i < 5; i++)
            {
                ScheduleButtons[i].onClick.RemoveAllListeners();
            }
            exitButton.onClick.RemoveAllListeners();
            pgLeftButton.onClick.RemoveAllListeners();
            pgRightButton.onClick.RemoveAllListeners();
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