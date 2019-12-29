using System.IO;
using System.Xml.Serialization;

namespace BinaryTreeLib.Serializer
{
    /// <summary>
    /// Type for serializing and deserializing generic objects.
    /// </summary>
    public static class Serialization
    {
        /// <summary>
        /// Serializing a generic object.
        /// </summary>
        /// <typeparam name="T">The type in the XmlSerialaizer.</typeparam>
        /// <param name="obj">Generic type to serialize.</param>
        public static void XmlSerialaizer<T>(T obj)
        {
            var objTypeName = obj.GetType().Name;
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(objTypeName + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Deserializing a generic object.
        /// </summary>
        /// <typeparam name="T">The type in the XmlSerialaizer.</typeparam>
        /// <param name="pathToXml">Path to the XML file.</param>
        /// <returns>Deserialized generic type.</returns>
        public static T XmlDeserialize<T>(string pathToXml)
        {
            FileInfo fileInfo = new FileInfo(pathToXml);

            if (!fileInfo.Exists)
            {
                throw new FileNotFoundException("Path to file is not correct.");
            }

            XmlSerializer formatter = new XmlSerializer(typeof(T));
            T newDeserialaize;

            using (FileStream fs = new FileStream(pathToXml, FileMode.OpenOrCreate))
            {
                newDeserialaize = (T)formatter.Deserialize(fs);
            }
            return newDeserialaize;
        }

    }
}
