using System;
using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Calendar
{
    public class CalendarViewModel:BaseViewModel
    {
        public int mActiveSelection;
        
        public Sprite[] bgSprites=new Sprite[4];
        public Image bgImage;
        
        protected override void ProcessString()
        {
            mActiveSelection=CalendarStatics.ActiveSelection;
        }

        protected override void UpdateView()
        {
            bgImage.sprite = bgSprites[mActiveSelection];
        }

        protected override void UpdateModel()
        {
            CalendarStatics.ActiveSelection=mActiveSelection;
        }
    }
}