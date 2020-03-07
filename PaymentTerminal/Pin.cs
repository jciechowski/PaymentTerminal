namespace PaymentTerminal
{
    public class Pin : ValueObject<Pin>
    {
        public string Value { get; }

        private Pin(string value)
        {
            Value = value;
        }

        public static Pin From(string value)
        {
            return new Pin(value);
        }

        protected override bool EqualsCore(Pin other)
        {
            if (other is null)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Pin x, Pin y)
        {
            if (ReferenceEquals(x, null))
                return ReferenceEquals(y, null);

            return x.Equals(y);
        }

        public static bool operator !=(Pin x, Pin y)
        {
            return !(x == y);
        }
    }
}