using HtmlToDocument.Enums;
using HtmlToDocument.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlToDocument;

/// <summary>
/// Класс для конвертации HTML-документа в различные форматы документа
/// </summary>
public class DocumentConvert
{
    /// <summary>
    /// Преобразование HTML-документа в заданный выходной формат в соответствии с типом документа, переданным в параметре <paramref name="typeDocument"/>
    /// </summary>
    /// <param name="htmlPath">Путь к HTML-документу.</param>
    /// <param name="outPath">Путь к выходному документу.</param>
    /// <param name="typeDocument">Тип документа, в который нужно конвертировать HTML-документ.</param>
    public void Convert(string htmlPath, string outPath, TypeDocument typeDocument)
    {
        var convert = GetConverter(typeDocument);
        convert?.Convert(htmlPath, outPath);
    }

    /// <summary>
    /// Получение объекта-конвертера в зависимости от типа документа, переданного в параметре <paramref name="typeDocument"/>
    /// </summary>
    /// <param name="typeDocument">Тип документа, в который нужно конвертировать HTML-документ.</param>
    /// <returns>Объект-конвертер <see cref="IConvert"/> в соответствии с заданным типом документа.</returns>
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
