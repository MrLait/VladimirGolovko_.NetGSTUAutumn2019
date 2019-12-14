using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace InheritanceInterfacesAbstractAndClasses.IO
{
    public class StreamIO
    {
        public static void SaveXmlDocumentUsingStreamWriter(XDocument document, string path)
        {
            using (StreamWriter stream = new StreamWriter(path))
            {
                document.Save(stream);
            }
        }

        public static XmlDocument LoadXmlDocumentUsingStreamReader(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string sb = string.Empty;
            using (StreamReader streamReader = new StreamReader(path))
            {
                string xmlData;
                // the file is reached.
                while ((xmlData = streamReader.ReadLine()) != null)
                {
                    sb += xmlData;
                }
                xmlDocument.Load(new StringReader(sb.ToString()));
            }
            return xmlDocument;
        }

    }
}
