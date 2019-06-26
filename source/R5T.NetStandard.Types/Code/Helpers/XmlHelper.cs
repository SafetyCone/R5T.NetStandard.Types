using System;
using System.Xml;


namespace R5T.NetStandard
{
    public static class XmlHelper
    {
        public const XmlNode SelectSingleNodeNotFound = null;


        public static bool SelectSingleNodeFound(XmlNode xmlNode)
        {
            var found = xmlNode != XmlHelper.SelectSingleNodeNotFound;
            return found;
        }
    }
}
