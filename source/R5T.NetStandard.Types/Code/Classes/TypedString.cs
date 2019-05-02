using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Allow wrapping a string with a specific type.
    /// This is helpful in creating strongly-typed string for stringly-typed data. Examples: diretory path.
    /// </summary>
    /// <remarks>
    /// Many objects are "stringly-typed". For example, project name, project directory name, and project directory path are all strings, but are really different types of string.
    /// Creating methods that operate on these different types of string is clumsy. Because overloading is not possible (all methods take in the same argument type, string), methods must have different names.
    /// These extra names require more effort by the writer, but by the user, since they have to sort through the confusion caused by having multiple names for what is really the same operation being applied to different input types.
    /// The resolution to this difficulty is creating types that merely contain a string.
    /// This base type provides the actual functionality, inheritors just provide a name for their type of string.
    /// </remarks>
    public abstract class TypedString : IEquatable<TypedString>, IComparable<TypedString>
    {
        public string Value { get; set; }


        public TypedString()
        {
        }

        public TypedString(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !obj.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var objAsTypedString = obj as TypedString;

            var isEqual = this.Equals_Internal(objAsTypedString);
            return isEqual;
        }

        protected virtual bool Equals_Internal(TypedString other)
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
            return this.Value;
        }

        public bool Equals(TypedString other)
        {
            if (other == null || !other.GetType().Equals(this.GetType()))
            {
                return false;
            }

            var isEqual = this.Equals_Internal(other);
            return isEqual;
        }

        public int CompareTo(TypedString other)
        {
            var output = this.Value.CompareTo(other.Value);
            return output;
        }
    }
}
