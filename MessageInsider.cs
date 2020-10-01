using System.Collections.Generic;

namespace UIser
{
    public struct MessageInsider
    {
        public List<object> Values;

        public MessageInsider(params object[] values)
        {
            Values = new List<object>();
            Values.AddRange(values);
        }
    }
}