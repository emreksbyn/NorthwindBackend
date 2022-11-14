using System;
using System.Linq;
using WcfService.Interfaces;

namespace WcfService.Concrete.PinTypes
{
    public class StringPinType : IBasePinType
    {
        public string GeneratePin(int numberDigits)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, numberDigits).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}