using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlToDocument.Interfaces
{
    internal interface IConvert
    {
        void Convert(string htmlPath, string outPath);
    }
}
