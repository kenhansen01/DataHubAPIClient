using Microsoft.VisualStudio.TestTools.UnitTesting;
using XmlToMarkdown.Elements;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace XmlToMarkdownTests
{
    [TestClass]
    public class XmlToMarkdownTests
    {
        static XDocument XmlDoc;
        static XElement XMLDocElement;
        static XElement XMLAssemblyElement;
        static XElement XMLClassElement;
        static XElement XMLPropertyElement;
        static XElement XMLConstructorElement;
        static XElement XMLCredentialsMethodElement;
        static IEnumerable<XElement> Members;

        [ClassInitialize]
        public static void CreateXMLDoc(TestContext context)
        {
            XmlDoc = XDocument.Load("DataHubAPIClient.xml");
            XMLDocElement = XmlDoc.Element("doc");
            XMLAssemblyElement = XMLDocElement.Element("assembly");
            Members = XMLDocElement.Element("members").Elements("member");
            XMLClassElement = Members.Where(m => m.Attribute("name").Value.Split(':')[0] == "T").FirstOrDefault();
            XMLPropertyElement = Members.Where(m => m.Attribute("name").Value.Split(':')[0] == "P").FirstOrDefault();
            XMLConstructorElement = Members.Where(m => m.Attribute("name").Value == "M:DataHubAPIClient.DataHubAPIRequests.DataHubRequests.#ctor(System.String,System.String,System.String,System.String,System.Net.Http.HttpClient)").FirstOrDefault();
            XMLCredentialsMethodElement = Members.Where(m => m.Attribute("name").Value == "M:DataHubAPIClient.DataHubAPIRequests.DataHubRequests.Base64Credentials(System.String,System.String)").FirstOrDefault();
        }

        [TestMethod]
        public void AssemblyElementTests()
        {
            AssemblyElement assemblyElement = new AssemblyElement(XMLAssemblyElement);
            Assert.AreEqual(XMLAssemblyElement.Element("name").Value, assemblyElement.ElementTextValue);
            Assert.AreEqual($"# {XMLAssemblyElement.Element("name").Value} #", assemblyElement.MarkdownValue);
        }

        [TestMethod]
        public void MemberElementTests()
        {
            // Type Element : Class
            MemberElement typeElement = new MemberElement(XMLClassElement);
            Assert.AreEqual($"## Class {XMLClassElement.Attribute("name").Value.Split('.').Last()}", typeElement.MarkdownValue);

            // Property Element : Property
            MemberElement propElement = new MemberElement(XMLPropertyElement);
            Assert.AreEqual($"#### Property {XMLPropertyElement.Attribute("name").Value.Split('.').Last()}", propElement.MarkdownValue);
        }

        [TestMethod]
        public void SummaryElementTests()
        {
            SummaryElement summaryElement = new SummaryElement(XMLConstructorElement.Element("summary"));
            Assert.AreEqual($@"
 {XMLConstructorElement.Element("summary").Value}", summaryElement.MarkdownValue);
        }

        [TestMethod]
        public void ParamTableElementTests()
        {
            XElement[] paramElements = XMLConstructorElement.Elements("param").ToArray();

            ParamTableElement paramTableElement = new ParamTableElement(paramElements);

            string expectedMdTable = @"
|Name | Description |
|-----|-----|";
            foreach (XElement param in paramElements)
            {
                expectedMdTable += $@"
|{param.Attribute("name").Value}: |{param.Value}|";
            }

            Assert.AreEqual(expectedMdTable, paramTableElement.MarkdownValue);
        }

        [TestMethod]
        public void ExampleElementTests()
        {
            ExampleElement exampleElement = new ExampleElement(XMLConstructorElement.Element("example"));
            Assert.AreEqual($"#### Example: {(XMLConstructorElement.Element("example").FirstNode as XText).Value}", exampleElement.MarkdownValue);
        }

        [TestMethod]
        public void CodeElementTests()
        {
            XElement xCodeElement = XMLConstructorElement.Element("example").Element("code");
            CodeElement codeElement = new CodeElement(xCodeElement);
            string expectedResult = $@"
```
    {xCodeElement.Value}
```";
            Assert.AreEqual(expectedResult, codeElement.MarkdownValue);
        }

        [TestMethod]
        public void ReturnsElementTests()
        {
            XElement credentialsReturnsElement = XMLCredentialsMethodElement.Element("returns");

            ReturnsElement returnsElement = new ReturnsElement(credentialsReturnsElement);

            Assert.AreEqual($"**Returns**: {credentialsReturnsElement.Value}", returnsElement.MarkdownValue);
        }
    }
}
