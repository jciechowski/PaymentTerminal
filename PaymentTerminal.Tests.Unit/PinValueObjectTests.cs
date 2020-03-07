using FluentAssertions;
using Xunit;

namespace PaymentTerminal.Tests
{
    public class PinValueObjectTests
    {
        [Fact]
        public void TwoSamePinsAreTheSameValues()
        {
            var pinValue = "1234";
            var pin = Pin.From(pinValue);
            var samePin = Pin.From(pinValue);

            pin.Should().Be(samePin);
        }

        [Fact]
        public void TwoDifferentPinsAreDifferentValues()
        {
            var pinValue = "2222";
            var otherPinValue = "1111";

            var pin = Pin.From(pinValue);
            var otherPin = Pin.From(otherPinValue);
            
            pin.Should().NotBe(otherPin);
        }

        [Fact]
        public void EqualityOperatorForSameValuesWorksCorrectly()
        {
            var pinValue = "1234";
            var pin = Pin.From(pinValue);
            var samePin = Pin.From(pinValue);

            (pin == samePin).Should().BeTrue();
        }

        [Fact]
        public void EqualityOperatorForOtherValuesWorksCorrectly()
        {
            var pinValue = "2222";
            var otherPinValue = "1111";

            var pin = Pin.From(pinValue);
            var otherPin = Pin.From(otherPinValue);

            (pin == otherPin).Should().BeFalse();
        }
    }
}