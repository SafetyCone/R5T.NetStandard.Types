using System;
using System.Text;


namespace R5T.NetStandard
{
    public static class StringBuilderExtensions
    {
        public static char LastChar(this StringBuilder builder)
        {
            var output = builder[builder.Length - 1];
            return output;
        }

        public static string Last(this StringBuilder builder)
        {
            if(builder.Length < 1)
            {
                return StringHelper.Invalid;
            }

            var output = builder.LastChar().ToString();
            return output;
        }

        public static void RemoveLast(this StringBuilder builder)
        {
            if(builder.Length > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
        }

        public static void RemoveFromEnd(this StringBuilder builder, string @string)
        {
            var stringLength = @string.Length;
            builder.Remove(builder.Length - stringLength, stringLength);
        }

        public static StringBuilder EndLineIfNotEnded(this StringBuilder builder, char endOfLine)
        {
            if (builder.LastChar() != endOfLine)
            {
                builder.Append(endOfLine);
            }

            return builder;
        }

        public static StringBuilder EndLineIfNotEnded(this StringBuilder builder, string endOfLine)
        {
            if (builder.Length > 0 && builder.Last() != endOfLine)
            {
                builder.Append(endOfLine);
            }

            return builder;
        }

        public static StringBuilder EndLineIfNotEnded(this StringBuilder builder)
        {
            builder.EndLineIfNotEnded(Environment.NewLine);

            return builder;
        }
    }
}
