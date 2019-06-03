using System;


namespace R5T.NetStandard
{
    public static class StringHelper
    {
        /// <summary>
        /// The return value of the <see cref="String.IndexOf(string)"/> method when the search string is not found.
        /// </summary>
        public const int IndexOfNotFound = -1;


        /// <summary>
        /// Useful for testing the return value of the <see cref="String.IndexOf(string)"/> method to see if the search string was found.
        /// </summary>
        public static bool IsFound(int index)
        {
            var isFound = index != StringHelper.IndexOfNotFound;
            return isFound;
        }
    }
}
