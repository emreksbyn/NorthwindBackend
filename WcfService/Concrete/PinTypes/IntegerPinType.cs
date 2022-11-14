using System;
using WcfService.Interfaces;

namespace WcfService.Concrete.PinTypes
{
    public class IntegerPinType : IBasePinType
    {
        public string GeneratePin(int numberDigits)
        {
            Random randomNumber = new Random();
            int minValue = int.Parse("1".PadRight(numberDigits, '0'));
            string pin = randomNumber.Next(minValue, minValue * 10).ToString();
            return pin;
        }
    }
}