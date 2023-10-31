using HtmlToDocument.Converters.Docx.Utils;
using HtmlToDocument.Interfaces;
using HtmlToDocument.Models;

using System.IO;

namespace HtmlToDocument.Converters.Docx;

/// <summary>
/// Класс для конвертации HTML-файлов в формат DOCX
/// Реализует интерфейс IConvert.
/// </summary>
internal class DocxConvert : IConvert
{
    /// <summary>
    /// Конвертирует указанный HTML-файл в формат DOCX и форматирует выходной файл.
    /// </summary>
    /// <param name="htmlPath">Путь к исходному HTML-файлу.</param>
    /// <param name="outPath">Путь для сохранения выходного DOCX-файла.</param>
    /// <param name="printOptions">Параметры печати для применения к выходному документу.</param>
    /// <exception cref="FileNotFoundException">Выбрасывается, если сконвертированный файл DOCX не может быть найден на диске.</exception>
    public void Convert(string htmlPath, string outPath, PrintOptions printOptions)
    {
        using (var dConvert = new Utils.DocumentFormat(htmlPath, outPath))
        {
            dConvert.Convert();
        }

        if (!File.Exists(outPath))
        {
            throw new FileNotFoundException("HTML-файл не был сконвертирован в формат DOCX.");
        }

        using var dInterop = new DocxInterop(outPath, printOptions);
        dInterop.Format();
    }
}

