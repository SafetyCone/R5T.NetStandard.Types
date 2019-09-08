using System;
using System.Collections.Generic;


namespace R5T.NetStandard
{
    /// <summary>
    /// Allows for a value to have a default value, but be overridden to have a different value.
    /// </summary>
    public class OverridableValue<T>
    {
        private readonly object zSynchonization = new object();
        public T Value { get; private set; }
        public T DefaultValue { get; private set; }
        public bool IsOverridden { get; private set; }


        public OverridableValue(T defaultValue)
        {
            this.DefaultValue = defaultValue;
            this.Value = this.DefaultValue;
            this.IsOverridden = false;
        }

        public void Override(T value)
        {
            lock(this.zSynchonization)
            {
                this.Value = value;
                this.IsOverridden = true;
            }
        }

        public void Reset()
        {
            lock(this.zSynchonization)
            {
                this.Value = this.DefaultValue;
                this.IsOverridden = false;
            }
        }
    }
}
