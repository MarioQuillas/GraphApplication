using System;

namespace CurrencyGraph.Domain
{
    public class Currency : IEquatable<Currency>
    {
        private readonly string shortName;

        public Currency(string shortName)
        {
            this.shortName = shortName;
        }

        // TODO : For testing simplicity purpose
        public static implicit operator Currency(string str)
        {
            return new Currency(str);
        }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(shortName, other.shortName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Currency) obj);
        }

        public override int GetHashCode()
        {
            return (shortName != null ? shortName.GetHashCode() : 0);
        }

        //TODO : for debugguing purpose
        public override string ToString()
        {
            return this.shortName;
        }
    }
}