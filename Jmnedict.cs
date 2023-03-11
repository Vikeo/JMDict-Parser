using System.Xml.Serialization;

namespace JMDict
{
    /// <summary>
    /// The JMnedict dictionary class.
    /// <para>
    /// This is the DTD of the Japanese-Multilingual Named Entity
    /// Dictionary file. It is based on the JMdict DTD, and carries
    /// many fields from it.It is used for a quick-and-dirty conversion
    /// of the ENAMDICT entries, plus the name entries from EDICTH.
    /// </para>
    /// </summary>
    [Serializable, XmlRoot("JMnedict")]
    public class Jmnedict : IDict
    {
        /// <summary>
        /// Entries consist of kanji elements, reading elements
        /// name translation elements.Each entry must have at
        /// least one reading element and one sense element.Others are optional.
        /// </summary>
        [XmlElement("entry")]
        public JmnedictEntry[]? Entries { get; set; }
    }

    /// <summary>
    /// The Entry element.
    /// <para>
    /// Entries consist of kanji elements, reading elements
    /// name translation elements.Each entry must have at
    /// least one reading element and one sense element.Others are optional.
    /// </para>
    /// </summary>
    public class JmnedictEntry
    {
        /// <summary>
        /// A unique numeric sequence number for each entry
        /// </summary>
        [XmlElement("ent_seq")]
        public int Sequence { get; set; }

        /// <summary>
        /// The kanji element, or in its absence, the reading element, is
        /// the defining component of each entry.
        /// <para>
        /// The overwhelming majority of entries will have a single kanji
        /// element associated with an entity name in Japanese.Where there are
        /// multiple kanji elements within an entry, they will be orthographical
        /// variants of the same word, either using variations in okurigana, or
        /// alternative and equivalent kanji.Common "mis-spellings" may be
        /// included, provided they are associated with appropriate information
        /// fields.Synonyms are not included; they may be indicated in the
        /// cross-reference field associated with the sense element.
        /// </para>
        /// </summary>
        [XmlElement("k_ele")]
        public JmnedictKanji[]? Kanji { get; set; }

        /// <summary>
        /// The reading element typically contains the valid readings
        /// of the word(s) in the kanji element using modern kanadzukai.
        /// <para>
        /// Where there are multiple reading elements, they will typically be
        /// alternative readings of the kanji element.In the absence of a
        /// kanji element, i.e. in the case of a word or phrase written
        /// entirely in kana, these elements will define the entry.
        /// </para>
        /// </summary>
        [XmlElement("r_ele")]
        public JmnedictReading[]? Readings { get; set; }

        /// <summary>
        /// The trans element will record the translational equivalent
        /// of the Japanese name, plus other related information.
        /// </summary>
        [XmlElement("trans")]
        public JmnedictTranslation[]? Sense { get; set; }
    }

    /// <summary>
    /// The kanji element, or in its absence, the reading element, is
    /// the defining component of each entry.
    /// <para>
    /// The overwhelming majority of entries will have a single kanji
    /// element associated with an entity name in Japanese.Where there are
    /// multiple kanji elements within an entry, they will be orthographical
    /// variants of the same word, either using variations in okurigana, or
    /// alternative and equivalent kanji.Common "mis-spellings" may be
    /// included, provided they are associated with appropriate information
    /// fields.Synonyms are not included; they may be indicated in the
    /// cross-reference field associated with the sense element.
    /// </para>
    /// </summary>
    public class JmnedictKanji
    {
        /// <summary>
        /// This element will contain an entity name in Japanese
        /// which is written using at least one non-kana character(usually
        /// kanji, but can be other characters). 
        /// <para>
        /// The valid characters are kanji, kana, related characters such as chouon and
        /// kurikaeshi, and in exceptional cases, letters from other alphabets.
        /// </para>
        /// </summary>
        [XmlElement("keb")]
        public string? Expression { get; set; }

        /// <summary>
        /// This is a coded information field related specifically to the
        /// orthography of the keb, and will typically indicate some unusual
        /// aspect, such as okurigana irregularity.
        /// </summary>
        [XmlElement("ke_inf")]
        public string[]? Information { get; set; }

        /// <summary>
        /// This and the equivalent re_pri field are provided to record
        /// information about the relative priority of the entry, and are for
        /// use either by applications which want to concentrate on entries of
        /// a particular priority, or to generate subset files.
        /// <para>
        /// The reason both the kanji and reading elements are tagged is because on
        /// occasions a priority is only associated with a particular
        /// kanji/reading pair.
        /// </para>
        /// </summary>
        [XmlElement("ke_pri")]
        public string[]? Priorities { get; set; }
    }

    /// <summary>
    /// The reading element typically contains the valid readings
    /// of the word(s) in the kanji element using modern kanadzukai.
    /// <para>
    /// Where there are multiple reading elements, they will typically be
    /// alternative readings of the kanji element.In the absence of a
    /// kanji element, i.e. in the case of a word or phrase written
    /// entirely in kana, these elements will define the entry.
    /// </para>
    /// </summary>
    public class JmnedictReading
    {
        /// <summary>
        /// This element content is restricted to kana and related
        /// characters such as chouon and kurikaeshi.Kana usage will be
        /// consistent between the keb and reb elements; e.g. if the keb
        /// contains katakana, so too will the reb.
        /// </summary>
        [XmlElement("reb")]
        public string? Reading { get; set; }

        /// <summary>
        /// This element is used to indicate when the reading only applies
        /// to a subset of the keb elements in the entry. 
        /// <para>
        /// In its absence, all readings apply to all kanji elements.The contents of this element
        /// must exactly match those of one of the keb elements.
        /// </para>
        /// </summary>
        [XmlElement("re_restr")]
        public string[]? Restrictions { get; set; }

        /// <summary>
        /// General coded information pertaining to the specific reading.
        /// <para>
        /// Typically it will be used to indicate some unusual aspect of
        /// the reading.
        /// </para>
        /// </summary>
        [XmlElement("re_inf")]
        public string[]? Information { get; set; }

        /// <summary>
        /// This and the equivalent ke_pri field are provided to record
        /// information about the relative priority of the entry, and are for
        /// use either by applications which want to concentrate on entries of
        /// a particular priority, or to generate subset files.
        /// <para>
        /// The reason both the kanji and reading elements are tagged is because on
        /// occasions a priority is only associated with a particular
        /// kanji/reading pair.
        /// </para>
        /// </summary>
        [XmlElement("re_pri")]
        public string[]? Priorities { get; set; }
    }

    /// <summary>
    /// The trans element will record the translational equivalent
    /// of the Japanese name, plus other related information.
    /// </summary>
    public class JmnedictTranslation
    {
        /// <summary>
        /// The type of name, recorded in the appropriate entity codes.
        /// </summary>
        [XmlElement("name_type")]
        public string[]? NameTypes { get; set; }

        /// <summary>
        /// This element is used to indicate a cross-reference to another
        /// entry with a similar or related meaning or sense.
        /// <para>
        /// The content of this element is typically a keb or reb element in another entry. In some
        /// cases a keb will be followed by a reb and/or a sense number to provide
        /// a precise target for the cross-reference.Where this happens, a JIS
        /// "centre-dot" (0x2126) is placed between the components of the
        /// cross-reference.
        /// </para>
        /// </summary>
        [XmlElement("xref")]
        public string[]? References { get; set; }

        /// <summary>
        /// The actual translations of the name, usually as a transcription
        /// into the target language.
        /// </summary>
        [XmlElement("trans_det")]
        public string[]? Translations { get; set; }

        /// <summary>
        /// The xml:lang attribute defines the target language of the
        /// translated name.
        /// <para>
        ///It will be coded using the three-letter language
        /// code from the ISO 639-2 standard.When absent, the value "eng"
        /// (i.e.English) is the default value.The bibliographic(B) codes
        /// are used.
        /// </para>
        /// </summary>
        [XmlAttribute("lang")]
        public string? Language { get; set; }
    }
}