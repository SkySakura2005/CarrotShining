using cfg.schedule;
using Managers;

namespace Statics
{
    public static class CalendarStatics
    {
        public static DateReaderDB cardData = new DateReaderDB(StaticManager.LoadJson("schedule_datereaderdb"));
        public static DateCardsDB[] cardSchedules = new DateCardsDB[7];
        public static int ActiveSelection=1;
    }
}