using System;
using System.Collections.Generic;

namespace CurrencyGraph.Domain
{
    public class Currency : IEquatable<Currency>
    {
        private readonly string shortName;

        public Currency(string shortName)
        {
            if (shortName == null || shortName.Length > 3) throw new ArgumentException("The curreny code can only be 3 character long");

            this.shortName = shortName;
        }

        // TODO : For testing simplicity purpose
        public static implicit operator Currency(string str)
        {
            return new Currency(str);
        }

        public override string ToString()
        {
            return this.shortName;
        }

        #region equals

        public bool Equals(Currency other)
        {
            // not use of == on 'other' since that operator will be overloaded afterwards and it can cause a infinite loop and then a stackoverflow exception.
            return !object.ReferenceEquals(other, null) && string.Equals(shortName, other.shortName);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Currency);
        }

        /// <summary>
        /// Returns a hash code for this instance. We implented it since the properties of this class are immutable.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table or dictionaries. 
        /// </returns>
        public override int GetHashCode()
        {
            return (shortName != null ? shortName.GetHashCode() : 0);
        }

        public static bool operator ==(Currency instance1, Currency instance2)
        {
            return EqualityComparer<Currency>.Default.Equals(instance1, instance2);
        }

        public static bool operator !=(Currency instance1, Currency instance2)
        {
            return !(instance1 == instance2);
        }

        #endregion
    }
}