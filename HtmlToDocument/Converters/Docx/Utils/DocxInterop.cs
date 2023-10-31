using HtmlToDocument.Converters.Docx.Extensions;
using HtmlToDocument.Models;

using Microsoft.Office.Interop.Word;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using Font = HtmlToDocument.Models.Font;
using Range = Microsoft.Office.Interop.Word.Range;

namespace HtmlToDocument.Converters.Docx.Utils;

/// <summary>
/// Класс, отвечающий за дополнительную обработку и настройку документов DOCX с помощью Microsoft.Office.Interop.Word.
/// </summary>
internal class DocxInterop : IDisposable
{
    private readonly PrintOptions _printOptions;
    private readonly Document _document;
    private readonly Application _application;

    /// <summary>
    /// Инициализирует новый экземпляр класса DocxInterop с указанным путем выходного DOCX-файла и параметрами печати.
    /// </summary>
    /// <param name="outPath">Путь к выходному файлу DOCX, который нужно обработать.</param>
    /// <param name="printOptions">Параметры печати для применения к документу.</param>
    public DocxInterop(string outPath, PrintOptions printOptions)
    {
        _printOptions = printOptions;
        _application = new Application();
        _document = _application.Documents.Open(FileName: outPath, ReadOnly: false);
    }

    /// <summary>
    /// Форматирует документ DOCX, используя заданные параметры печати.
    /// </summary>
    public void Format()
    {
        ChangeFont(_printOptions.Font);
        ChangeOrientation(_printOptions.PageOrientation);

        if (_printOptions.Attachments.Any())
        {
            AddAttachments(_printOptions.Attachments);
        }
    }

    /// <summary>
    /// Изменяет шрифт документа на заданный.
    /// </summary>
    /// <param name="font">Шрифт, который нужно использовать в документе.</param>
    private void ChangeFont(Font font)
    {
        var range = _document.Range();
        range.Font.Size = font.Size;
        range.Font.Name = font.Name;
    }

    /// <summary>
    /// Изменяет ориентацию страниц документа на заданную.
    /// </summary>
    /// <param name="orientation">Ориентация страниц, которую нужно использовать в документе.</param>
    private void ChangeOrientation(PageOrientation orientation)
    {
        _document.Sections.PageSetup.Orientation = orientation.ToWdOrientation();
    }

    /// <summary>
    /// Добавляет в документ заданные в параметрах печати вложения вместо искомых ключей.
    /// </summary>
    /// <param name="attachments">Список вложений, которые нужно добавить в документ.</param>
    private void AddAttachments(IEnumerable<Attachment> attachments)
    {
        foreach (var item in attachments)
        {
            var nameFile = Path.GetFileName(item.Key);
            var parameters = GetFindParameters($"[{nameFile}]", Missing.Value);
            var range = _document.Range();

            var isFound = (bool)range.Find
                .GetType()
                .InvokeMember("Execute", BindingFlags.InvokeMethod, null, range.Find, parameters);

            if (isFound)
            {
                AddAttachments(range, item.Pathes);
            }
        }
    }

    /// <summary>
    /// Добавляет в документ заданные вложения вместо указанного диапазона.
    /// </summary>
    /// <param name="rangeObject">Диапазон документа, который нужно заменить вложением.</param>
    /// <param name="attachments">Список вложений, которые нужно добавить в документ.</param>
    private void AddAttachments(Range rangeObject, IEnumerable<string> attachments)
    {
        rangeObject.Select();
        rangeObject.Delete();

        foreach (var item in attachments)
        {
            _application.Selection.InlineShapes.AddObject(item, rangeObject);
        }
    }

    /// <summary>
    /// Возвращает параметры для поиска искомой строки.
    /// </summary>
    /// <param name="flagFileName">Строка для поиска.</param>
    /// <param name="missingObject">Объект, который указывает на неопределенное значение.</param>
    /// <returns>Массив параметров для поиска искомой строки.</returns>
    private object[] GetFindParameters(string flagFileName, object missingObject)
    {
        const int parameterCount = 15;

        return Enumerable.Repeat(missingObject, parameterCount)
            .Select((_, i) => i == 0 ? flagFileName : missingObject)
            .ToArray();
    }

    /// <summary>
    /// Освобождает ресурсы, используемые объектами <see cref="Document"/> и <see cref="Application"/> .
    /// </summary>
    public void Dispose()
    {
        _document?.Close();
        ReleaseComObject(_document);

        _application?.Quit();
        ReleaseComObject(_application);

        static void ReleaseComObject(object? obj)
        {
            if (obj is not null)
            {
                Marshal.FinalReleaseComObject(obj);
            }
        }
    }
}
