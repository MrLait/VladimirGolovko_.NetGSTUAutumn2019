using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace InheritanceInterfacesAbstractAndClasses.IO
{
    public class XmlIO
    {
        public static void SaveXmlDocumentUsingXmlWriter(XDocument document, string path)
        {
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;
            xws.Indent = true;

            using (XmlWriter xw = XmlWriter.Create(path, xws))
            {
                document.WriteTo(xw);
            }
        }

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
