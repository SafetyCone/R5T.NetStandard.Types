using System;


namespace R5T.NetStandard
{
    /// <summary>
    /// Interface for types whose instances are named (have a name).
    /// </summary>
    public interface INamed
    {
        string Name { get; }
    }
}
