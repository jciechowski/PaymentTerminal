using System;
using Chill;
using FluentAssertions;
using PaymentTerminal;
using Xunit;

namespace PaymentTermina.Tests.BDD
{
    namespace ForPayingWithCard
    {
        public class WhenHadEnoughMoneyOnCard : GivenSubject<Terminal, CreditCard>
        {
            public WhenHadEnoughMoneyOnCard()
            {
                // Given(() => new CreditCard(Money.From(50), Pin.From("1234"), DateTime.Now.AddYears(1)));
                
                When(() => Subject.Charge(new CreditCard(Money.From(50), Pin.From("1234"), DateTime.Now.AddYears(1)), Pin.From("1234"), Money.From(5)));
            }

            [Fact]
            public void CardChargeSucceeded()
            {
                Result.GetBalance(Pin.From("1234")).Amount.Should().Be(Money.From(45).Amount);
            }
        }
    }
}