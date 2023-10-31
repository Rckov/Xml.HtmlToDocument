using HtmlToDocument.Converters.Docx.Extensions;
using HtmlToDocument.Models;

using Microsoft.Office.Interop.Word;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

using Font = HtmlToDocument.Models.Font;

namespace HtmlToDocument.Converters.Docx.Utils;
internal class DocxInterop : IDisposable
{
    private readonly PrintOptions _printOptions;

    private readonly Document _document;
    private readonly Application _application;

    public DocxInterop(string outPath, PrintOptions printOptions)
    {
        _printOptions = printOptions;

        _application = new Application();
        _document = _application.Documents.Open(FileName: outPath, ReadOnly: false);
    }

    public void Format()
    {
        ChangeFont(_printOptions.Font);
        ChangeOrientation(_printOptions.PageOrientation);

        if (_printOptions.Attachments.Any())
        {
            AddAttachments(_printOptions.Attachments);
        }
    }

    private void ChangeFont(Font font)
    {
        _document.Range().Font.Size = font.Size;
        _document.Range().Font.Name = font.Name;
    }

    private void ChangeOrientation(PageOrientation orientation)
    {
        _document.Sections.PageSetup.Orientation = orientation.ToWdOrientation();
    }

    private void AddAttachments(IEnumerable<Attachment> attachments)
    {
        var rangeObject = _document.Range();

        foreach (Attachment item in attachments)
        {
            var nameFile = Path.GetFileName(item.Key);
            var parameters = GetFindParameters($"[{nameFile}]", Missing.Value);

            var findObject = rangeObject.Find;

            var isFound = (bool)rangeObject.Find
                .GetType()
                .InvokeMember("Execute", BindingFlags.InvokeMethod, null, rangeObject.Find, parameters);

            if (isFound)
            {
                AddAttachments(rangeObject, item.Pathes);
            }
        }
    }

    private void AddAttachments(Microsoft.Office.Interop.Word.Range rangeObject, IEnumerable<string> attachments)
    {
        rangeObject.Select();
        _ = rangeObject.Delete();

        foreach (string item in attachments)
        {
            _ = _application.Selection.InlineShapes.AddObject(item, rangeObject);
        }
    }

    private object[] GetFindParameters(string flagFileName, object missingObject)
    {
        const int parameterCount = 15;

        return Enumerable.Repeat(missingObject, parameterCount)
            .Select((_, i) => i == 0 ? flagFileName : missingObject)
            .ToArray();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
