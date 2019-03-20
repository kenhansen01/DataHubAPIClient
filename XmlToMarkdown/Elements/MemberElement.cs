using System;
using System.Xml;
using System.Xml.Linq;
using XmlToMarkdownTests.Elements;

namespace XmlToMarkdown.Elements
{
    public class MemberElement : IMemberElement
    {
        private string attributeNameValue;
        private MemberElementKind elementType;
        private string elementTextValue;
        private string[] fullyQualifiedMemberName;
        private string memberName;
        private string markdownValue;

        public MemberElement(XElement memberElement)
        {
            AttributeNameValue = memberElement.Attribute("name").Value;

            string typeCode = attributeNameValue.Split(':')[0];

            FullyQualifiedMemberName = attributeNameValue.Split(':')[1].Split('.');
            MemberName = fullyQualifiedMemberName[fullyQualifiedMemberName.Length - 1];
            ElementType = MemberType(typeCode, memberName);

            // If there's a text value for the member Element set it. Super unlikely. 
            if (memberElement.FirstNode.NodeType == XmlNodeType.Text) ElementTextValue = (memberElement.FirstNode as XText).Value;
            else ElementTextValue = String.Empty;

            // If this is a Type set as H2 Markdown, else set to H4 Markdown
            if (Array.IndexOf(new string[] { "Interface", "Delegate", "Class" }, elementType.ToString()) > -1) MarkdownValue = $"## {elementType} {memberName}";
            else MarkdownValue = $"#### {elementType} {memberName}";
        }

        public string AttributeNameValue { get => attributeNameValue; set => attributeNameValue = value; }
        public MemberElementKind ElementType { get => elementType; set => elementType = value; }
        public string ElementTextValue { get => elementTextValue; set => elementTextValue = value; }
        public string[] FullyQualifiedMemberName { get => fullyQualifiedMemberName; set => fullyQualifiedMemberName = value; }
        public string MemberName { get => memberName; set => memberName = value; }
        public string MarkdownValue { get => markdownValue; set => markdownValue = value; }

        private MemberElementKind MemberType(string memberTypeCode, string memberShortName)
        {
            MemberElementKind tName = MemberElementKind.None;
            if (memberTypeCode == "T")
            {
                switch (memberShortName)
                {
                    case "I":
                        if (memberShortName.StartsWith("I"))
                            tName = MemberElementKind.Interface;
                        break;
                    case "Delegate":
                        if (memberShortName.EndsWith("Delegate"))
                            tName = MemberElementKind.Delegate;
                        break;
                    default:
                        tName = MemberElementKind.Class;
                        break;
                }
            }
            else
            {
                switch (memberTypeCode)
                {
                    case "F":
                        tName = MemberElementKind.Field;
                        break;
                    case "P":
                        tName = MemberElementKind.Property;
                        break;
                    case "M":
                        tName = MemberElementKind.Method;
                        break;
                    case "E":
                        tName = MemberElementKind.Event;
                        break;
                    case "!":
                        tName = MemberElementKind.ErrorString;
                        break;
                    default:
                        tName = MemberElementKind.AssemblyMember;
                        break;
                }
            }
            return tName;
        }
    }
}
