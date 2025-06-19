using System;

namespace Statics
{
    public static class BaseStatics
    {
        
        public static int Year=DateTime.Now.Year;
        public static BoxedValues<int> Week=new BoxedValues<int>(1);
        public static int Day = 1;
    }
}