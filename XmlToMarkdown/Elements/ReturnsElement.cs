using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class ReturnsElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public ReturnsElement(XElement returnsElement)
        {
            if (returnsElement.Attribute("name") != null)
                AttributeNameValue = returnsElement.Attribute("name").Value;
            else
                AttributeNameValue = string.Empty;
            ElementTextValue = returnsElement.Value;
            MarkdownValue = $@"**Returns**: {elementTextValue}";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
}
