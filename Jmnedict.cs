using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JMDict
{
    [Serializable, XmlRoot("JMnedict")]
    public class Jmnedict : IDict
    {
        [XmlElement("entry")]
        public JmnedictEntry[] Entries { get; set; }
    }

    public class JmnedictEntry
    {
        [XmlElement("ent_seq")]
        public int Sequence { get; set; }

        [XmlElement("k_ele")]
        public JmnedictKanji[] Kanji { get; set; }

        [XmlElement("r_ele")]
        public JmnedictReading[] Readings { get; set; }

        [XmlElement("trans")]
        public JmnedictTranslation[] Sense { get; set; }
    }

    public class JmnedictKanji
    {
        [XmlElement("keb")]
        public string Expression { get; set; }

        [XmlElement("ke_inf")]
        public string[] Information { get; set; }

        [XmlElement("ke_pri")]
        public string[] Priorities { get; set; }
    }

    public class JmnedictReading
    {
        [XmlElement("reb")]
        public string Reading { get; set; }

        [XmlElement("re_restr")]
        public string[] Restrictions { get; set; }

        [XmlElement("re_inf")]
        public string[] Information { get; set; }

        [XmlElement("re_pri")]
        public string[] Priorities { get; set; }
    }

    public class JmnedictTranslation
    {
        [XmlElement("name_type")]
        public string[] NameTypes { get; set; }

        [XmlElement("xref")]
        public string[] References { get; set; }

        [XmlElement("trans_det")]
        public string[] Translations { get; set; }

        [XmlAttribute("lang")]
        public string Language { get; set; }
    }
}
