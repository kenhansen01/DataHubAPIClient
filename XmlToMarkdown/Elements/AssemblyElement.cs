using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class AssemblyElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public AssemblyElement(XElement assemblyElement)
        {
            AttributeNameValue = assemblyElement.Element("name").Value;
            ElementTextValue = attributeNameValue;
            MarkdownValue = $"# {elementTextValue} #";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
}
