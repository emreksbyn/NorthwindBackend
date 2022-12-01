using System.ComponentModel;
using System;

namespace Business.Constants
{
    public static class MessagesExtensions
    {
        public static string SendMessages(this Messages value)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType()
                                                                             .GetField(value.ToString())
                                                                             .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : String.Empty;
        }
    }
}