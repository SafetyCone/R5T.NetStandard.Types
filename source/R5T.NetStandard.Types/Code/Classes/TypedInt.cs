using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Allow wrapping an integer with a specific type.
    /// This is helpful in creating strongly-typed strings for intgeger-typed data.
    /// Value is read-only.
    /// </summary>
    public abstract class TypedInt : IEquatable<TypedInt>, IComparable<TypedInt>
    {
        public int Value { get; }


        public TypedInt(int value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTypedString = obj as TypedInt;

            var isEqual = this.Equals_Internal(objAsTypedString);
            return isEqual;
        }

        protected virtual bool Equals_Internal(TypedInt other)
        {
            var isEqual = this.Value.Equals(other.Value);
            return isEqual;
        }

        public override int GetHashCode()
        {
            var hashCode = this.Value.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            var output = this.Value.ToString();
            return output;
        }

        public bool Equals(TypedInt other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }

        public int CompareTo(TypedInt other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
