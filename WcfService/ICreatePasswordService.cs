using System.ServiceModel;

namespace WcfService
{
    [ServiceContract]
    public interface ICreatePasswordService
    {
        [OperationContract]
        string GenerateStringPin();

        [OperationContract]
        string GenerateIntegerPin();
    }
}