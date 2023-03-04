using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JMDict
{
    [Serializable, XmlRoot("kanjidic2")]
    public class Kanjidic : IDict
    {
        [XmlElement("header")]
        public KanjidicHeader Header { get; set; }

        [XmlElement("character")]
        public KanjidicCharacter[] Characters { get; set; }
    }

    public class KanjidicHeader
    {
        [XmlElement("file_version")]
        public string FileVersion { get; set; }

        [XmlElement("database_version")]
        public string DatabaseVersion { get; set; }

        [XmlElement("date_of_creation")]
        public string DateOfCreation { get; set; }
    }

    public class KanjidicCharacter
    {
        [XmlElement("literal")]
        public string Literal { get; set; }

        [XmlElement("codepoint")]
        public KanjidicCodepoint Codepoint { get; set; }

        [XmlElement("radical")]
        public KanjidicRadical Radical { get; set; }

        [XmlElement("misc")]
        public KanjidicMisc Misc { get; set; }

        [XmlElement("dic_number")]
        public KanjidicDicNumber[] DictionaryNumbers { get; set; }

        [XmlElement("query_code")]
        public KanjidicQueryCode QueryCode { get; set; }

        [XmlElement("reading_meaning")]
        public KanjidicReadingMeaning ReadingMeaning { get; set; }
    }

    public class KanjidicCodepoint
    {
        [XmlElement("cp_value")]
        public KanjidicCodePointValue[] Values { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class KanjidicCodePointValue
    {
        [XmlAttribute("cp_type")]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class KanjidicRadical
    {
        [XmlElement("rad_value")]
        public KanjidicRadicalValue[] Values { get; set; }
    }

    public class KanjidicRadicalValue
    {
        [XmlAttribute("rad_type")]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
        
        [XmlElement("re_restr")]
        public string[] Restrictions { get; set; }

        [XmlElement("re_inf")]
        public string[] Information { get; set; }

        [XmlElement("re_pri")]
        public string[] Priorities { get; set; }
    }

    public class KanjidicMisc
    {
        [XmlElement("grade")]
        public string Grade { get; set; }

        [XmlElement("stroke_count")]
        public string[] StrokeCounts { get; set; }

        [XmlElement("variant")]
        public KanjidicVariant[] Variants { get; set; }
        
        [XmlElement("freq")]
        public string Frequency { get; set; }

        [XmlElement("rad_name")]
        public string[] RadicalName { get; set; }

        [XmlElement("jlpt")]
        public string JlptLevel { get; set; }
    }

    public class KanjidicVariant
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("var_type")]
        public string Type { get; set; }
    }

    public class KanjidicDicNumber
    {
        [XmlElement("dic_ref")]
        public KanjidicDicRef[] Values { get; set; }
    }

    public class KanjidicDicRef
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("dr_type")]
        public string Type { get; set; }

        [XmlAttribute("m_vol")]
        public string Volume { get; set; }

        [XmlAttribute("m_page")]
        public string Page { get; set; }
    }

    public class KanjidicQueryCode
    {
        [XmlElement("q_code")]
        public List<QueryCode> QueryCodes { get; set; }
    }


    public class QueryCode
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("qc_type")]
        public string Type { get; set; }

        [XmlAttribute("skip_misclass")]
        public string Misclassification { get; set; }
    }
    
    public class KanjidicReadingMeaning
    {
        [XmlElement("rmgroup")]
        public ReadingMeaningGroup[] ReadingMeaningGroups { get; set; }

        [XmlElement("nanori")]
        public string[] Nanori { get; set; }
    }

    public class ReadingMeaningGroup
    {
        [XmlElement("reading")]
        public List<KanjidicReading> Readings { get; set; }

        [XmlElement("meaning")]
        public List<KanjidicMeaning> Meanings { get; set; }
    }

    public class KanjidicReading
    {
        [XmlText]
        public string Value { get; set; }

        [XmlAttribute("r_type")]
        public string Type { get; set; }

        // Currently not used
        [XmlAttribute("on_type")]
        public string OnType { get; set; }

        // Currently not used
        [XmlAttribute("r_status")]
        public string JouyouStatus { get; set; }
    }

    public class KanjidicMeaning
    {
        [XmlText]
        public string Meaning { get; set; }

        [XmlAttribute("m_lang")]
        public string Language { get; set; }
    }
}
