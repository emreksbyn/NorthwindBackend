using System.ComponentModel;
using System;

namespace Core.Utilities.Messages
{
    public static class AspectMessagesExtensions
    {
        public static string SendMessages(this AspectMessages value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType()
                                                                             .GetField(value.ToString())
                                                                             .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }
    }
}