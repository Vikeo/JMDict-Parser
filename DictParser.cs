using System.Xml.Serialization;
using System.Xml;

namespace JMDict
{
    /// <summary>
    /// Class for prarsing <see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/> dictionaries.
    /// </summary>
    public class DictParser
    {
        private readonly XmlReaderSettings _xmlReaderSettings = new()
        {
            DtdProcessing = DtdProcessing.Parse,
            MaxCharactersFromEntities = 0
        };

        /// <summary>
        /// <para>Opens a filestream for the XML file and returns it as a chosen dictionary class object. The file stream is closed before return.</para>
        /// Requires a class that implements <see cref="IDict"/> interface (<see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/>).
        /// </summary>
        /// <param name="filePath">Path to the XML file.</param>
        /// <typeparam name="IDict"><see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/> implements <see cref="IDict"/></typeparam>
        public IDict ParseXml<IDict>(string filePath)
        {
            using FileStream fileStream = new(filePath, FileMode.Open);
            using XmlReader xmlReader = XmlReader.Create(fileStream, _xmlReaderSettings);
            return DeserializeJMDict<IDict>(xmlReader);
        }

        /// <summary>
        /// <para>Receives a stream for a appropriate XML file and returns it as the chosen dictionary class object.</para>
        /// Requires a class that implements <see cref="IDict"/> interface (<see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/>).
        /// </summary>
        /// <param name="fileStream">Stream with a appropriate XML file.</param>
        /// <typeparam name="IDict"><see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/> implements <see cref="IDict"/></typeparam>
        public IDict ParseXml<IDict>(Stream fileStream)
        {
            using (XmlReader xmlReader = XmlReader.Create(fileStream, _xmlReaderSettings))
            {
                return DeserializeJMDict<IDict>(xmlReader);
            }
        }

        /// <summary>
        /// <para>Method for deserialising the input XML file.</para>
        /// Requires a class that implements <see cref="IDict"/> interface. (<see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/>)
        /// </summary>
        /// <param name="xmlReader"><see cref="XmlReader"/>  instance containing a appropriate xml file stream.</param>
        /// <typeparam name="IDict"><see cref="JMDict"/>, <see cref="Kanjidic"/> or <see cref="Jmnedict"/> implements <see cref="IDict"/></typeparam>
        private static IDict DeserializeJMDict<IDict>(XmlReader xmlReader)
        {
            var xmlSerializer = new XmlSerializer(typeof(IDict));
            try
            {
                if (xmlSerializer.Deserialize(xmlReader) is not IDict result)
                {
                    throw new Exception($"Deserialized result is null");
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Could not deserialize: ", e);
            }
        }
    }
}
