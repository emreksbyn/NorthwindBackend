using WcfService.Interfaces;

namespace WcfService.PinFactoryRepository
{
    public abstract class PinFactory
    {
        protected abstract IBasePinType MakePinGenerator();

        public IBasePinType CreatePinGenerator()
        {
            return MakePinGenerator();
        }
    }
}