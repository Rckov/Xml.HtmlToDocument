Конвертер HTML в PDF и DOCX на C#

Библиотека на C# позволяет просто и удобно конвертировать HTML файлы в PDF и DOCX форматы. Полученные файлы выглядят профессионально и готовы к использованию.

### Использование

Чтобы начать использование библиотеки, достаточно передать ей HTML файл и указать нужный формат вывода. 

```csharp
using HtmlToDocument;

private void Convert(string htmlPath, string outPath, TypeDocument typeDocument, PrintOptions printOptions)
{
    _documentConvert = _documentConvert ?? new DocumentConvert();
    _documentConvert.Convert(htmlPath, outPath, typeDocument, printOptions);
}
```
