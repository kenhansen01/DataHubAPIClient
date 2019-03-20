using System;
using System.Linq;
using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class ParamElement : IDocElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;

        public ParamElement(XElement paramElement)
        {

            if (paramElement.Attribute("name") != null)
                AttributeNameValue = paramElement.Attribute("name").Value;
            else
                AttributeNameValue = string.Empty;
            ElementTextValue = paramElement.Value;
            MarkdownValue = $"|{attributeNameValue}: |{elementTextValue}|";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }
    }
    public class ParamTableElement
    {
        private string attributeNameValue;
        private string elementTextValue;
        private string markdownValue;
        private ParamElement[] paramElements;

        public ParamTableElement(XElement[] paramEls)
        {
            AttributeNameValue = String.Empty;
            ElementTextValue = attributeNameValue;
            ParamElements = paramEls.Select(p => new ParamElement(p)).ToArray();
            MarkdownValue = $@"
|Name | Description |
|-----|-----|{paramElements.Select(x => $@"
{x.MarkdownValue}").Aggregate((c, n) => c + n)}";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }

        public ParamElement[] ParamElements { get => paramElements; set => paramElements = value; }
    }
}
