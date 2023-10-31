using HtmlToDocument.Models;

using Microsoft.Office.Interop.Word;

using System.IO;

namespace HtmlToDocument.Converters.Docx.Extensions;

/// <summary>
/// Статический класс, содержащий методы-расширения.
/// </summary>
internal static class InteropExtensions
{
    /// <summary>
    /// Преобразует ориентацию страницы в соответствующее значение перечисления <see cref="WdOrientation"/>.
    /// </summary>
    /// <param name="orientation">Ориентация страницы.</param>
    /// <returns>Значение перечисления <see cref="WdOrientation"/>.</returns>
    public static WdOrientation ToWdOrientation(this PageOrientation orientation)
    {
        return orientation switch
        {
            PageOrientation.Portrait => WdOrientation.wdOrientPortrait,
            PageOrientation.Landscape => WdOrientation.wdOrientLandscape,
            _ => default,
        };
    }

    /// <summary>
    /// Добавляет объект в коллекцию встроенных объектов в документе Word.
    /// </summary>
    /// <param name="inlineShapes">Коллекция встроенных объектов в документе Word.</param>
    /// <param name="objectPath">Путь к объекту.</param>
    /// <param name="range">Диапазон, в котором будет размещен объект.</param>
    /// <returns>Возвращает <see cref="InlineShape"/>, представляющий добавленный объект.</returns>
    public static InlineShape AddObject(this InlineShapes inlineShapes, string objectPath, Range range)
    {
        var fullPath = Path.GetFullPath(objectPath);
        var extension = Path.GetExtension(fullPath);

        return extension.ToLower() switch
        {
            ".png" or
            ".jpg" or
            ".jpeg" => inlineShapes.AddPicture(fullPath, false, true, range),
            _ => inlineShapes.AddOLEObject(FileName: fullPath, Range: range),
        };
    }
}
