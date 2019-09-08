using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    /// <summary>
    /// Allows for a value to have an intial value, but be set to have a different value, and to indicate if its value has been set to something other than the initial value.
    /// Also allows unsetting the value, back to its initial value.
    /// </summary>
    public class SettableValue<T>
    {
        private readonly object zSynchonization = new object();
        public T Value { get; private set; }
        public T InitialValue { get; private set; }
        public bool IsSet { get; private set; }


        public SettableValue(T initialValue)
        {
            this.InitialValue = initialValue;
            this.Value = this.InitialValue;
            this.IsSet = false;
        }

        public SettableValue(T initialValue, T value)
            : this(initialValue)
        {
            this.Set(value);
        }

        public void Set(T value)
        {
            lock (this.zSynchonization)
            {
                this.Value = value;
                this.IsSet = true;
            }
        }

        public void Reset()
        {
            lock (this.zSynchonization)
            {
                this.Value = this.InitialValue;
                this.IsSet = false;
            }
        }
    }
}
