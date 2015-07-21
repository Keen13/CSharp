namespace PaymentSystemApi
{
    public class PaymentResult
    {
        public PaymentResult(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public bool IsSuccessful { get; private set; }

        public string Message { get; private set; }
    }
}