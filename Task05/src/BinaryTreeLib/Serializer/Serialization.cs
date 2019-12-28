using System;
using System.IO;
using System.Xml.Serialization;

namespace BinaryTreeLib.Serializer
{
    public static class Serialization
    {
        public static void XmlSerialaizer<T>(T obj)
        {
            var objTypeName = obj.GetType().Name;
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream fs = new FileStream(objTypeName + ".xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public static T XmlDeserialize<T>(string pathToXml)
        {
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
