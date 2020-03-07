using System;
using System.Security.Authentication;

namespace PaymentTerminal
{
    public class CreditCard
    {
        public Money Balance { get; private set; }
        public DateTime ExpireAt { get; }
        private Pin Pin { get; }

        public CreditCard(
            Money balance,
            Pin pin,
            DateTime expireAt)
        {
            Balance = balance;
            Pin = pin;
            ExpireAt = expireAt;
        }

        private bool VerifyPin(Pin pin)
        {
            return pin == Pin;
        }

        private void ChangeBalance(Pin pin, Money newBalance)
        {
            if (VerifyPin(pin))
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
            var pinIsCorrect = VerifyPin(creditCardPin);

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