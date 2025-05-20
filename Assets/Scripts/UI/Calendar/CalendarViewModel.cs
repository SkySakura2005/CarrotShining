using System;
using System.Collections.Generic;
using cfg.schedule;
using Statics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarViewModel:BaseViewModel
    {
        public int mActiveSelection;
        public int[] currentIndex = { 0, 0, 0, 0 };
        
        private List<DateCardsDB> currentDateCards=new List<DateCardsDB>();
        private int tmpSelectedIndex;
        
        public Sprite[] bgSprites=new Sprite[4];
        public Image bgImage;
        public GameObject currentCards;
        
        protected override void Initialize()
        {
            mActiveSelection = CalendarStatics.ActiveSelection;
            tmpSelectedIndex = -1;
        }
        protected override void UpdateModel()
        {
            CalendarStatics.ActiveSelection=mActiveSelection;
        }

        protected override void UpdateView()
        {
            bgImage.sprite = bgSprites[mActiveSelection];
            for (int i = 0; i < 5; i++)
            {
                Text nameText=currentCards.transform.GetChild(i).Find("NameText").GetComponent<Text>();
                if (i < currentDateCards.Count)
                {
                    nameText.text = currentDateCards[i].DateName;
                    currentCards.transform.GetChild(i).GetComponent<Button>().interactable=true;
                }
                else
                {
                    nameText.text = string.Empty;
                    currentCards.transform.GetChild(i).GetComponent<Button>().interactable=false;
                }
                
            }
        }

        

        protected override void ProcessString()
        {
            if (tmpSelectedIndex != mActiveSelection)
            {
                
                currentDateCards.Clear();
                int cnt = 0;
                foreach (var item in CalendarStatics.cardData.DataList)
                {
                    int selection;
                    selection=getTypeFromSelection(item);
                    Debug.Log("Loop is entered and cnt is "+cnt);
                    if (selection == mActiveSelection&&item.Unlocked)
                    {
                        cnt++;
                        if (cnt >= currentIndex[mActiveSelection] * 5 + 1) currentDateCards.Add(item);
                        else if (cnt > currentIndex[mActiveSelection] * 5 + 5) break;
                    }
                    else if (selection> mActiveSelection)
                    {
                        Debug.Log("TypeId is "+item.SchuduledAction.GetTypeId());
                        break;
                    }
                }
                tmpSelectedIndex = mActiveSelection;
            }
            
        }
        int getTypeFromSelection(DateCardsDB dateCard)
        {
            if (dateCard.SchuduledAction is Notice)
            {
                return 0;
            }
            else if (dateCard.SchuduledAction is Course)
            {
                return 1;
            }
            else if (dateCard.SchuduledAction is Work)
            {
                return 2;
            }
            else if (dateCard.SchuduledAction is Rest)
            {
                return 3;
            }
            return -1;
        }
    }

    
}