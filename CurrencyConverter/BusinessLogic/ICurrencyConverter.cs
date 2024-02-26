using System.ServiceModel;

namespace CurrencyConverter.BusinessLogic
{
    [ServiceContract]
    public interface ICurrencyConverter
    {
        [OperationContract]
        public Amount ConvertToDkk(Amount amount);
    }

    public class SoapService : ICurrencyConverter
    {
        public Amount ConvertToDkk(Amount amount)
        {
            Amount result = new();
            result.Currency = "DKK";
            if(amount.Currency == "USD")
            {
                result.Value = amount.Value * 6.53;
                return result;
            } else
            {
                return amount;
            }
        }
    }

}
