using System;
using System.Xml;
using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class ExampleElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public ExampleElement(XElement exampleElement)
        {
            if (exampleElement.Attribute("name") != null)
                AttributeNameValue = exampleElement.Attribute("name").Value;
            else
                AttributeNameValue = string.Empty;

            if (exampleElement.FirstNode.NodeType == XmlNodeType.Text)
                ElementTextValue = (exampleElement.FirstNode as XText).Value;
            else
                ElementTextValue = String.Empty;

            MarkdownValue = $@"#### Example: {elementTextValue}";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
}
