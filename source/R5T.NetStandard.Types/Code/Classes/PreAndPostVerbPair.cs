using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Useful for describing before- and after-action results.
    /// </summary>
    public class PreAndPostVerbPair
    {
        public string Pre { get; set; }
        public string Post { get; set; }


        public PreAndPostVerbPair()
        {
        }

        public PreAndPostVerbPair(string pre, string post)
        {
            this.Pre = pre;
            this.Post = post;
        }
    }
}
