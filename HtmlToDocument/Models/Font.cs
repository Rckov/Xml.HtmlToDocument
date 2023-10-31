namespace HtmlToDocument.Models;

/// <summary>
/// Класс, представляющий шрифт.
/// </summary>
public class Font
{
    /// <summary>
    /// Название шрифта.
    /// </summary>
    public string Name { get; set; } = "Times New Roman";

    /// <summary>
    /// Размер шрифта.
    /// </summary>
    public int Size { get; set; } = 14;
}
