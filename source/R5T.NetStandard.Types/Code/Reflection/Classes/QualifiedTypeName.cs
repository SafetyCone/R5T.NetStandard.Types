using System;


namespace R5T.NetStandard.Reflection
{
    public class QualifiedTypeName
    {
        public NamespaceName NamespaceName { get; }
        public TypeName TypeName { get; }


        public QualifiedTypeName(NamespaceName namespaceName, TypeName typeName)
        {
            this.NamespaceName = namespaceName;
            this.TypeName = typeName;
        }
    }
}
