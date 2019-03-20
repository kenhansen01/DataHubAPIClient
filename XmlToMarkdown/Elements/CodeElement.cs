using System;
using System.Xml;
using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class CodeElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public CodeElement(XElement codeElement)
        {
            if (codeElement.Attribute("name") != null)
                AttributeNameValue = codeElement.Attribute("name").Value;
            else
                AttributeNameValue = string.Empty;
            ElementTextValue = codeElement.Value;
            MarkdownValue = $@"
```
    {elementTextValue}
```";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
}
