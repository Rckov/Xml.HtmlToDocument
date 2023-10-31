using HtmlToDocument.Models;

namespace HtmlToDocument.Interfaces;

/// <summary>
/// Интерфейс, который определяет метод конвертации HTML-файла в другой формат с использованием опций печати.
/// </summary>
internal interface IConvert
{
    /// <summary>
    /// Конвертирует HTML-файл в другой формат с использованием опций печати.
    /// </summary>
    /// <param name="htmlPath">Путь к HTML-файлу.</param>
    /// <param name="outPath">Путь для сохранения конвертированного файла.</param>
    /// <param name="printOptions">Опции печати.</param>
    void Convert(string htmlPath, string outPath, PrintOptions printOptions);
}
