using HtmlToDocument.Enums;
using HtmlToDocument.Interfaces;
using HtmlToDocument.Models;

using System;

namespace HtmlToDocument;

/// <summary>
/// Класс для конвертации HTML-документов в различные форматы, такие как PDF или DOCX.
/// </summary>
public class DocumentConvert
{
    /// <summary>
    /// Метод конвертации HTML-документа.
    /// </summary>
    /// <param name="htmlPath">Путь к HTML-файлу.</param>
    /// <param name="outPath">Путь для сохранения конвертированного файла.</param>
    /// <param name="typeDocument">Формат, в который нужно сконвертировать документ (PDF, DOCX).</param>
    /// <param name="printOptions">Опции для печати документа.</param>
    public void Convert(string htmlPath, string outPath, TypeDocument typeDocument, PrintOptions? printOptions = null)
    {
        var convert = GetConverter(typeDocument);
        convert?.Convert(htmlPath, outPath, printOptions ?? new PrintOptions());
    }

    /// <summary>
    /// Возвращает конвертер для заданного типа документа.
    /// </summary>
    /// <param name="typeDocument">Тип документа (PDF, DOCX).</param>
    /// <returns>Интерфейс конвертера IConvert.</returns>
    private IConvert GetConverter(TypeDocument typeDocument)
    {
        return typeDocument switch
        {
            TypeDocument.Pdf => null!,
            TypeDocument.Docx => null!,
            _ => throw new InvalidOperationException($"Undefined convert type {typeDocument}")
        };
    }
}