using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Main
{
    public class MainViewModel:BaseViewModel
    {
        public Text YearText;
        public Text DayText;
        public Text WeekdayText;
        
        public Text MoodText;
        public Text LuckText;
        public Text ExpText;
        public Text HealthText;
        
        public Text CoinText;
        public Text FansText;
        
        private string mYearText;
        private string mDayText;
        private string mWeekdayText;
        
        private string mMoodText;
        private string mLuckText;
        private string mExpText;
        private string mHealthText;
        
        private string mCoinText;
        private string mFansText;
        protected override void ProcessString()
        {
            mYearText = BaseStatics.Year.ToString() + "年";
            switch (BaseStatics.Day/28)
            {
                case 0:
                    mDayText = "春 "+(BaseStatics.Day%28).ToString()+" 日";
                    break;
                case 1:
                    mDayText = "夏 "+(BaseStatics.Day%28).ToString()+" 日";
                    break;
                case 2:
                    mDayText = "秋 "+(BaseStatics.Day%28).ToString()+" 日";
                    break;
                case 3:
                    mDayText = "冬 "+(BaseStatics.Day%28).ToString()+" 日";
                    break;
            }
            mWeekdayText="第"+(BaseStatics.Day/7+1).ToString()+"周 星期";
            switch (BaseStatics.Day % 7)
            {
                case 0:
                    mWeekdayText += "日";
                    break;
                case 1:
                    mWeekdayText += "一";
                    break;
                case 2:
                    mWeekdayText += "二";
                    break;
                case 3:
                    mWeekdayText += "三";
                    break;
                case 4:
                    mWeekdayText += "四";
                    break;
                case 5:
                    mWeekdayText += "五";
                    break;
                case 6:
                    mWeekdayText += "六";
                    break;
            }
            
            mMoodText=CharacterStatics.Mood.ToString()+"/"+CharacterStatics.MaxMood.ToString();
            mLuckText=CharacterStatics.Luck.ToString()+"/"+CharacterStatics.MaxLuck.ToString();
            mHealthText=CharacterStatics.Health.ToString()+"/"+CharacterStatics.MaxHealth.ToString();
            
            mCoinText=CharacterStatics.Coin.ToString()+"G";
            mFansText = CharacterStatics.Fans.ToString();
        }

        protected override void UpdateView()
        {
            YearText.text=mYearText;
            DayText.text=mDayText;
            WeekdayText.text=mWeekdayText;
            MoodText.text=mMoodText;
            LuckText.text=mLuckText;
            ExpText.text=mExpText;
            HealthText.text=mHealthText;
            CoinText.text=mCoinText;
            FansText.text=mFansText;
        }

        protected override void UpdateModel()
        {
            
        }
    }
}