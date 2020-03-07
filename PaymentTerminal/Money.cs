namespace PaymentTerminal
{
    public class Money : ValueObject<Money>
    {
        public decimal Amount { get; }

        private Money(decimal amount) => Amount = amount;

        public static Money From(decimal amount) => new Money(amount);

        protected override bool EqualsCore(Money other)
        {
            if (other is null)
            {
                return false;
            }

            return Amount.Equals(other.Amount);
        }

        protected override int GetHashCodeCore() => Amount.GetHashCode();

        public static bool operator >(Money a, Money b) => a.Amount > b.Amount;

        public static bool operator <(Money a, Money b) => a.Amount < b.Amount;

        public static Money operator -(Money a, Money b) => new Money(a.Amount - b.Amount);

        public static Money operator +(Money a, Money b) => new Money(a.Amount + b.Amount);
    }
}