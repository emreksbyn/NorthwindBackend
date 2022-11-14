using WcfService.Concrete.PinTypes;
using WcfService.Interfaces;

namespace WcfService.PinFactoryRepository
{
    public class GenerateIntegerPin : PinFactory
    {
        protected override IBasePinType MakePinGenerator()
        {
            IBasePinType integerPin = new IntegerPinType();
            return integerPin;
        }
    }
}