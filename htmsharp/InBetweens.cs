using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htmsharp
{
    public class InBetweens
    {
        public struct Html
        {
            private static string PureHTML { get; set; }
            public Html(string htm)
            {
                PureHTML = htm;
            }
            public static class GetInBtws
            {
                public static string GetInBetweens(string blockname)
                {
                    return PureHTML.Split(new string[] { $"<{blockname}>" }, StringSplitOptions.None)[1];
                }
            }
            public static class GetProp
            {
                /// <summary>
                /// Gets the data from an HTML property.
                /// </summary>
                /// <param name="propname">The property name.</param>
                /// <returns></returns>
                public static string GetProperties(string propname)
                {
                    return PureHTML.Split(new string[] { $"{propname}=" }, StringSplitOptions.None)[1].Replace('"', char.MinValue);
                }
            }
        }
    }
}
