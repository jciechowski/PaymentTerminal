using System;
using System.Threading.Tasks;

namespace PaymentTerminal
{
    public class Terminal
    {
        // charge card
        // refund to card
        // withdraw from card
        // gsm top-up
        // blik
        // NFC
        // contact less payment with card
        public void WithdrawMoney(
            CreditCard creditCard,
            Money amountToWithdraw,
            Pin pin)
        {
            var creditCardBalance = creditCard.GetBalance(pin);

            if (creditCardBalance < amountToWithdraw)
            {
                throw new ArgumentOutOfRangeException();
            }

            // creditCard.
        }

        public CreditCard Charge(
            CreditCard creditCard,
            Pin creditCardPin,
            Money chargeAmount)
        {
            var creditCardBalance = creditCard.GetBalance(creditCardPin);
            if (creditCardBalance > chargeAmount)
            {
                var chargedCreditCard = creditCard.Charge(chargeAmount, creditCardPin);

                return chargedCreditCard;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}