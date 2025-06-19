namespace Statics
{
    public class BoxedValues<T> where T : struct
    {
        private object _value;

        public BoxedValues(T outerValue)
        {
            _value = outerValue;
        }
        
        public T Value{get{return (T)_value;}set => _value = value;}
    }
}