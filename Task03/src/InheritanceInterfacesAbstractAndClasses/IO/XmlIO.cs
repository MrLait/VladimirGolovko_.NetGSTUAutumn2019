using System.Xml;
using System.Xml.Linq;

namespace InheritanceInterfacesAbstractAndClasses.IO
{
    /// <summary>
    /// Static type to save and load XML document using XmlWriter and XmlReadder
    /// </summary>
    public static class XmlIO
    {
        /// <summary>
        /// Static method to save xDocument using XmlWriter.
        /// </summary>
        /// <param name="document">Input xDocument.</param>
        /// <param name="path">Path to file to save xDocument.</param>
        public static void SaveXmlDocumentUsingXmlWriter(XDocument document, string path)
        {
            XmlWriterSettings xws = new XmlWriterSettings
            {
                OmitXmlDeclaration = true,
                Indent = true
            };

            using (XmlWriter xw = XmlWriter.Create(path, xws))
            {
                document.WriteTo(xw);
            }
        }

        /// <summary>
        /// Static method to load xml using XmlReader.
        /// </summary>
        /// <param name="path">Path to file to load xml document using XmlReader.</param>
        /// <returns>Returns xmlDocuments.</returns>
        public static XmlDocument LoadXmlDocumentUsingXmlReader(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                reader.Read();
                xmlDocument.Load(reader);
            }
            return xmlDocument;
        }

    }
}
