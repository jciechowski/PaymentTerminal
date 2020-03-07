using System;
using System.Security.Authentication;

namespace PaymentTerminal
{
    public class CreditCard
    {
        public Money Balance { get; }
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

        public bool VerifyPin(Pin pin)
        {
            return pin == Pin;
        }

        public Money GetBalance(Pin pin)
        {
            if (pin == Pin)
            {
                return Balance;
            }

            throw new UnauthorizedAccessException();
        }

        public CreditCard Charge(Money chargeAmount, Pin creditCardPin)
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
            
            return new CreditCard(newBalance, Pin, ExpireAt);
        }
    }
}