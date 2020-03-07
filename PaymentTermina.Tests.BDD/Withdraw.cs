using System;
using Chill;
using FluentAssertions;
using PaymentTerminal;
using Xunit;

namespace PaymentTermina.Tests.BDD
{
    namespace ForWithdrawingMoney
    {
        public class WhenWithdrawMoneyFromCard : GivenSubject<Terminal, Money>
        {
            private CreditCard _creditCard;

            public WhenWithdrawMoneyFromCard()
            {
                Given(() =>
                    _creditCard = new CreditCard(Money.From(50), Pin.From("1234"), DateTime.Now.AddYears(1)));
                When(() => Subject.WithdrawMoney(_creditCard, Money.From(5), Pin.From("1234")));
            }

            [Fact]
            public void ThenCreditCardWasCharged()
            {
                _creditCard.GetBalance(Pin.From("1234")).Amount.Should().Be(Money.From(45).Amount);
            }

            [Fact]
            public void ThenMoneyWasReturned()
            {
                Result.Should().Be(Money.From(5));
            }
        }
    }
}