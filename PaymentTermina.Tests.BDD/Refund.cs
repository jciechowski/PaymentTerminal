using System;
using Chill;
using FluentAssertions;
using PaymentTerminal;
using Xunit;

namespace PaymentTermina.Tests.BDD
{
    namespace ForRefundingMoney
    {
        public class WhenRefundWasRequested : GivenSubject<Terminal>
        {
            private CreditCard _creditCard;

            public WhenRefundWasRequested()
            {
                Given(() => _creditCard = new CreditCard(Money.From(50), Pin.From("1234")));

                When(() =>
                {
                    Subject.Charge(_creditCard, Pin.From("1234"), Money.From(5));
                    Subject.Refund(_creditCard, Money.From(5));
                });
            }

            [Fact]
            public void ThenMoneyWasRefunded()
            {
                _creditCard.GetBalance(Pin.From("1234")).Should().Be(Money.From(50));
            }
        }
    }
}