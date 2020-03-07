using System;
using System.Security.Authentication;

namespace PaymentTerminal
{
    public class CreditCard
    {
        private Money Balance { get; set; }
        private Pin Pin { get; }

        public CreditCard(
            Money balance,
            Pin pin)
        {
            Balance = balance;
            Pin = pin;
        }

        private bool PinVerified(Pin pin)
        {
            return pin == Pin;
        }

        private void ChangeBalance(Pin pin, Money newBalance)
        {
            if (PinVerified(pin))
            {
                Balance = newBalance;
            }
        }

        public Money GetBalance(Pin pin)
        {
            if (pin == Pin)
            {
                return Balance;
            }

            throw new UnauthorizedAccessException();
        }

        public void Charge(Money chargeAmount, Pin creditCardPin)
        {
            var pinIsCorrect = PinVerified(creditCardPin);

            if (!pinIsCorrect)
            {
                throw new UnauthorizedAccessException();
            }

            if (chargeAmount > Balance)
            {
                throw new ArgumentOutOfRangeException();
            }

            var newBalance = Balance - chargeAmount;

            ChangeBalance(creditCardPin, newBalance);
        }

        public void AddToBalance(Money refundAmount)
        {
            ChangeBalance(Pin, Balance + refundAmount);
        }
    }
}