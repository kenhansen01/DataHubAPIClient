using XmlToMarkdown.Elements;

namespace XmlToMarkdownTests.Elements
{
    /// <summary>
    /// Documentation Element Interface
    /// </summary>
    public interface IDocElement
    {
        /// <summary>
        /// Attribute Name Value
        /// <para>Generally set to the <c>name</c> attribute.</para>
        /// <para>Defaults to null.</para>
        /// </summary>
        string AttributeNameValue { get; set; }
        /// <summary>
        /// Element Text Value
        /// <para>Generally the value of an element's Text Nodes.</para>
        /// </summary>
        string ElementTextValue { get; set; }
        /// <summary>
        /// Markdown string returned for the element.
        /// </summary>
        string MarkdownValue { get; set; }
    }

    public enum MemberElementKind
    {
        None = 0,
        Class = 1,
        Interface = 2,
        Delegate = 3,
        Enum = 4,
        Struct = 5,
        Field = 6,
        Property = 7,
        Method = 8,
        Event = 9,
        ErrorString = 10,
        AssemblyMember = 11
    }
        
        
//        if (memberTypeCode == "T")
//            {
//                switch (memberShortName)
//                {
//                    case "I":
//                        if (memberShortName.StartsWith("I"))
//                            tName = "Interface";
//                        break;
//                    case "Delegate":
//                        if (memberShortName.EndsWith("Delegate"))
//                            tName = "Delegate";
//                        break;
//                    default:
//                        tName = "Class";
//                        break;
//    }
//}
     

    /// <summary>
    /// Member Element Interface
    /// </summary>
    public interface IMemberElement : IDocElement
    {
        /// <summary>
        /// Member Type
        /// </summary>
        MemberElementKind ElementType { get; set; }
        string[] FullyQualifiedMemberName { get; set; }
        string MemberName { get; set; }
    }

}
