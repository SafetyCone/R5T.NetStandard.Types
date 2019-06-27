using System;


namespace R5T.NetStandard
{
    public class Typed<T> : IEquatable<Typed<T>>
    {
        public T Value { get; }


        public Typed(T value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTyped = obj as Typed<T>;

            var isEqual = this.Equals_Internal(objAsTyped);
            return isEqual;
        }

        protected virtual bool Equals_Internal(Typed<T> other)
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

        public bool Equals(Typed<T> other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }
    }
}
