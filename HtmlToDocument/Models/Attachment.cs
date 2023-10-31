using System.Collections.Generic;

namespace HtmlToDocument.Models;

/// <summary>
/// Класс, представляющий вложение.
/// </summary>
public class Attachment
{
    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="key">Ключ вложения.</param>
    /// <param name="pathes">Пути к файлам вложения.</param>
    public Attachment(string key, IEnumerable<string> pathes)
    {
        Key = key;
        Pathes = pathes;
    }

    /// <summary>
    /// Ключ вложения.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Пути к файлам вложения.
    /// </summary>
    public IEnumerable<string> Pathes { get; set; }
}