using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class SummaryElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public SummaryElement(XElement summaryElement)
        {
            if (summaryElement.Attribute("name") != null)
                AttributeNameValue = summaryElement.Attribute("name").Value;
            else
                AttributeNameValue = string.Empty;
            ElementTextValue = summaryElement.Value;
            MarkdownValue = $@"
 {elementTextValue}";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
}
