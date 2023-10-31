using System.Collections.Generic;
using System.Linq;

namespace HtmlToDocument.Models;

/// <summary>
/// Класс, представляющий настройки печати документов.
/// </summary>
public class PrintOptions
{
    /// <summary>
    /// Устанавливает или получает шрифт для печати документов.
    /// </summary>
    public Font Font { get; set; } = new Font();

    /// <summary>
    /// Устанавливает или получает ориентацию страницы для печати документов.
    /// </summary>
    public PageOrientation PageOrientation { get; set; } = PageOrientation.Portrait;

    /// <summary>
    /// Устанавливает или получает вложение для печати документов.
    /// </summary>
    public IEnumerable<Attachment> Attachments { get; set; } = Enumerable.Empty<Attachment>();
}