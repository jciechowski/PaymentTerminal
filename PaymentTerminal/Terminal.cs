using System;
using System.Threading.Tasks;

namespace PaymentTerminal
{
    public class Terminal
    {
        // D. charge card
        // refund to card
        // D. withdraw from card
        // gsm top-up
        // blik
        // NFC
        // contact less payment with card
        public Money WithdrawMoney(
            CreditCard creditCard,
            Money amountToWithdraw,
            Pin pin)
        {
            var creditCardBalance = creditCard.GetBalance(pin);

            if (creditCardBalance > amountToWithdraw)
            {
                creditCard.Charge(amountToWithdraw, pin);

                return amountToWithdraw;
            }

            throw new ArgumentOutOfRangeException();
        }

        public void Charge(
            CreditCard creditCard,
            Pin creditCardPin,
            Money chargeAmount)
        {
            var creditCardBalance = creditCard.GetBalance(creditCardPin);

            if (creditCardBalance > chargeAmount)
            {
                creditCard.Charge(chargeAmount, creditCardPin);
                return;
            }

            throw new ArgumentOutOfRangeException();
        }

        public void Refund(CreditCard creditCard, Money refundAmount)
        {
            creditCard.AddToBalance(refundAmount);
        }
    }
}