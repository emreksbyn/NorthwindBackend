using WcfService.Interfaces;
using WcfService.PinFactoryRepository;

namespace WcfService
{
    public class CreatePasswordService : ICreatePasswordService
    {
        public string GenerateStringPin()
        {
            IBasePinType stringPinType = new GenerateStringPin().CreatePinGenerator();
            string pin = stringPinType.GeneratePin(6);
            return pin;
        }
        public string GenerateIntegerPin()
        {
            IBasePinType intPinType = new GenerateIntegerPin().CreatePinGenerator();
            string pin = intPinType.GeneratePin(6);
            return pin;
        }
    }
}