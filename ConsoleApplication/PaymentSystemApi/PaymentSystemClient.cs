using System;

namespace PaymentSystemApi
{
    public class PaymentSystemClient
    {
        private const string SuccessMessage = "Payment is successful";
        private const string FailMessage = "Payment is failed. Try again later.";

        // This code  imitate response from  external payment system.
        // It returns "Success" at random  rate 3/4.
        public PaymentResult SendPayment(PaymentData paymentData)
        {
            var randomHexValue = Convert.ToUInt32("0x" + Guid.NewGuid().ToString()[15], 16);
            return randomHexValue < 12 ? new PaymentResult(true, SuccessMessage) : new PaymentResult(false, FailMessage);
        }
    }
}
