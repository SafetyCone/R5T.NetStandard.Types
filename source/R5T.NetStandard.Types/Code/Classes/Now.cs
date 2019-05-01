using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Operates in two modes: offset and absolute.
    /// Offset mode allows applying an offset to the current time to get a different now. This is useful for testing. For example, you can set the time to be January 1st, ask for Now.DateTime and then test whether the returned now is a holiday (which it will be). 
    /// Absolute mode allows setting the time for now. Until the specified time is changed, the same now will always be returned.
    /// </summary>
    public static class Now
    {
        public static NowMode Mode { get; private set; }

        public static DateTime AbsoluteNow { get; private set; }

        /// <summary>
        /// The offset applied to the machine DateTime.Now to get get the Now.DateTime.
        /// </summary>
        public static TimeSpan Offset { get; private set; } = TimeSpan.Zero;


        public static void SetMode(NowMode mode)
        {
            Now.Mode = mode;
        }

        /// <summary>
        /// Sets the offset such that right now is the specified now.
        /// </summary>
        public static void SetNowLocal(DateTime nowLocal)
        {
            switch (Now.Mode)
            {
                case NowMode.Absolute:
                    Now.AbsoluteNow = nowLocal;
                    break;

                case NowMode.Offset:
                    Now.Offset = Now.ComputeOffset(nowLocal);
                    break;

                default:
                    throw new Exception(EnumHelper.GetUnexpectedEnumerationValueMessage(Now.Mode));
            }
        }

        public static void SetNowUTC(DateTime nowUTC)
        {
            var nowLocal = nowUTC.ToLocalTime();

            Now.SetNowLocal(nowLocal);
        }

        /// <summary>
        /// Computes the offset from DateTime.Now to the specified now
        /// </summary>
        public static TimeSpan ComputeOffset(DateTime now)
        {
            var output = now - DateTime.Now;
            return output;
        }

        #region Outputs

        /// <summary>
        /// Depending on the mode, either the machine DateTime.Now adjusted by the offset (offset), or the previously specified now (absolute).
        /// </summary>
        public static DateTime DateTime
        {
            get
            {
                switch (Now.Mode)
                {
                    case NowMode.Absolute:
                        return Now.AbsoluteNow;

                    case NowMode.Offset:
                        var output = DateTime.Now + Now.Offset;
                        return output;

                    default:
                        throw new Exception(EnumHelper.GetUnexpectedEnumerationValueMessage(Now.Mode));
                }
            }
        }
        /// <summary>
        /// Depending on the mode, either the machine DateTime.Now adjusted by the offset (offset), or the previously specified now (absolute).
        /// Converted from the machine timezone to the UTC +00:00 default timezone.
        /// </summary>
        public static DateTime DateTimeUTC
        {
            get
            {
                var dateTime = Now.DateTime;

                var output = dateTime.ToUniversalTime();
                return output;
            }
        }

        public static DateTimeOffset DateTimeOffset
        {
            get
            {
                var dateTime = Now.DateTime;

                var dateTimeOffset = new DateTimeOffset(dateTime);
                return dateTimeOffset;
            }
        }

        #endregion
    }


    public enum NowMode
    {
        Offset,
        Absolute,
    }
}
