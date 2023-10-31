using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

using System;
using System.IO;

namespace HtmlToDocument.Converters.Docx.Utils;

/// <summary>
/// Представляет утилитарный класс для конвертации HTML в формат DOCX с помощью OpenXml.
/// </summary>
internal class DocumentFormat : IDisposable
{
    private readonly string _htmlPath;
    private readonly WordprocessingDocument _wordprocessing;

    /// <summary>
    /// Инициализирует новый экземпляр класса DocumentFormat с указанными путями HTML-файла и выходного файла DOCX.
    /// </summary>
    /// <param name="htmlPath">Путь к HTML-файлу, который должен быть сконвертирован.</param>
    /// <param name="outPath">Путь для выходного файла DOCX.</param>
    public DocumentFormat(string htmlPath, string outPath)
    {
        _htmlPath = htmlPath;
        _wordprocessing = WordprocessingDocument.Create(outPath, WordprocessingDocumentType.Document);
    }

    /// <summary>
    /// Конвертирует HTML-файл, указанный в конструкторе, в формат DOCX.
    /// </summary>
    public void Convert()
    {
        var generateID = "generateId1";

        var mainDocumentPart = GetMainDocumentPart(_wordprocessing);
        var formatImportPart = mainDocumentPart.AddAlternativeFormatImportPart(AlternativeFormatImportPartType.Html, generateID);

        using (var fileStream = new FileStream(_htmlPath, FileMode.Open))
        {
            formatImportPart.FeedData(fileStream);
        }

        mainDocumentPart.Document.Body?.InsertAt(new AltChunk { Id = generateID }, 0);
    }

    /// <summary>
    /// Возвращает основную часть документа WordprocessingDocument. Если основная часть не существует, то она будет создана.
    /// </summary>
    /// <param name="document">Документ WordprocessingDocument.</param>
    /// <returns>Основная часть документа WordprocessingDocument.</returns>
    private static MainDocumentPart GetMainDocumentPart(WordprocessingDocument document)
    {
        var mainDocPart = document.MainDocumentPart;

        if (mainDocPart == null)
        {
            mainDocPart = document.AddMainDocumentPart();
            mainDocPart.Document = new Document();
            mainDocPart.Document.AppendChild(new Body());
        }

        return mainDocPart;
    }

    /// <summary>
    /// Сохраняет и уничтожает экземпляр WordprocessingDocument.
    /// </summary>
    public void Dispose()
    {
        _wordprocessing?.Save();
        _wordprocessing?.Dispose();
    }
}