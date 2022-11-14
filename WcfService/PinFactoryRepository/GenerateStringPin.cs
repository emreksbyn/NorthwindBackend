using WcfService.Concrete.PinTypes;
using WcfService.Interfaces;

namespace WcfService.PinFactoryRepository
{
    public class GenerateStringPin : PinFactory
    {
        protected override IBasePinType MakePinGenerator()
        {
            IBasePinType stringPin = new StringPinType();
            return stringPin;
        }
    }
}