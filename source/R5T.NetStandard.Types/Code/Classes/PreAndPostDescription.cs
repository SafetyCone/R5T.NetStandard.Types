using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Useful for describing before- and after-action results.
    /// </summary>
    public class PreAndPostDescription
    {
        public PreAndPostVerbPair Verbs { get; set; }
        public string Description { get; set; }


        public PreAndPostDescription()
        {
        }

        public PreAndPostDescription(PreAndPostVerbPair verbs, string description)
        {
            this.Verbs = verbs;
            this.Description = description;
        }

        public PreAndPostDescription(string pre, string post, string description)
            : this(new PreAndPostVerbPair(pre, post), description)
        {
        }

        public string PreDescription()
        {
            var output = $"{this.Verbs.Pre} {this.Description}...";
            return output;
        }

        public string PostDescription()
        {
            var output = $"{this.Verbs.Post} {this.Description}.";
            return output;
        }
    }
}
