using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JMDict
{
    /// <summary>
    /// The root JMDict element.
    /// </summary>
    [Serializable, XmlRoot("JMdict")]
    public class JMDict : IDict
    {
        /// <summary>
        /// <para>Entries consist of kanji elements, reading elements,
        /// general information and sense elements.</para>
        /// Each entry must have at least one reading element and one 
        /// sense element. Others are optional.
        /// </summary>
        [XmlElement("entry")]
        public JMDictEntry[] Entries { get; set; }
    }

    /// <summary>
    /// <para>Entries consist of kanji elements, reading elements,
    /// general information and sense elements.</para>
    /// Each entry must have at least one reading element and one 
    /// sense element. Others are optional.
    /// </summary>
    public class JMDictEntry
    {
        /// <summary>
        /// A unique numeric sequence number for each entry
        /// </summary>
        [XmlElement("ent_seq")]
        public int Sequence { get; set; }

        /// <summary>
        /// <para>The kanji element, or in its absence, the reading element, is
        /// the defining component of each entry.</para>
        /// The overwhelming majority of entries will have a single kanji
        /// element associated with a word in Japanese. Where there are
        /// multiple kanji elements within an entry, they will be orthographical
        /// variants of the same word, either using variations in okurigana, or
        /// alternative and equivalent kanji. Common "mis-spellings" may be
        /// included, provided they are associated with appropriate information
        /// fields. Synonyms are not included; they may be indicated in the
        /// cross-reference field associated with the sense element.
        /// </summary>
        [XmlElement("k_ele")]
        public JMDictKanji[] Kanji { get; set; }

        /// <summary>
        /// <para>
        /// The reading element typically contains the valid readings of the 
        /// word(s) in the kanji element using modern kanadzukai.
        /// </para>
        /// Where there are multiple reading elements, they will typically be
        /// alternative readings of the kanji element.In the absence of a
        /// kanji element, i.e. in the case of a word or phrase written
        /// entirely in kana, these elements will define the entry.
        /// </summary>
        [XmlElement("r_ele")]
        public JMDictReading[] Readings { get; set; }

        /// <summary>
        /// The sense element will record the translational equivalent
        /// of the Japanese word, plus other related information.Where there
        /// are several distinctly different meanings of the word, multiple
        /// sense elements will be employed.
        /// </summary>
        [XmlElement("sense")]
        public JMDictSense[] SenseElements { get; set; }
    }

    /// <summary>
    /// <para>
    /// The kanji element, or in its absence, the reading element, is
    /// the defining component of each entry.
    /// </para>
    /// 
    /// The overwhelming majority of entries will have a single kanji
    /// element associated with a word in Japanese. Where there are
    /// multiple kanji elements within an entry, they will be orthographical
    /// variants of the same word, either using variations in okurigana, or
    /// alternative and equivalent kanji. Common "mis-spellings" may be
    /// included, provided they are associated with appropriate information
    /// fields. Synonyms are not included; they may be indicated in the
    /// cross-reference field associated with the sense element.
    /// </summary>
    public class JMDictKanji
    {
        /// <summary>
        /// <para>
        /// This element will contain a word or short phrase in Japanese
        /// which is written using at least one non-kana character(usually kanji,
        /// but can be other characters).
        /// </para>
        /// The valid characters are
        /// kanji, kana, related characters such as chouon and kurikaeshi, and
        /// in exceptional cases, letters from other alphabets.
        /// </summary>
        [XmlElement("keb")]
        public string Expression { get; set; }

        /// <summary>
        /// This is a coded information field related specifically to the
        /// orthography of the keb, and will typically indicate some unusual
        /// aspect, such as okurigana irregularity.
        /// </summary>
        [XmlElement("ke_inf")]
        public string[] Information { get; set; }

        /// <summary>
        /// <para>
        /// This and the equivalent re_pri field are provided to record
        /// information about the relative priority of the entry, and consist
        /// of codes indicating the word appears in various references which
        /// can be taken as an indication of the frequency with which the word
        /// is used.This field is intended for use either by applications which
        /// want to concentrate on entries of a particular priority, or to
        /// generate subset files.
        /// </para>
        /// The current values in this field are:
        /// <para>
        /// - news1/2: appears in the "wordfreq" file compiled by Alexandre Girardi
        /// from the Mainichi Shimbun. (See the Monash ftp archive for a copy.)
        /// Words in the first 12,000 in that file are marked "news1" and words
        /// in the second 12,000 are marked "news2".
        /// </para>
        /// <para>
        /// - ichi1/2: appears in the "Ichimango goi bunruishuu", Senmon Kyouiku
        /// Publishing, Tokyo, 1998.  (The entries marked "ichi2" were
        /// demoted from ichi1 because they were observed to have low
        /// frequencies in the WWW and newspapers.)
        /// </para>
        /// <para>
        /// - spec1 and spec2: a small number of words use this marker when they
        /// are detected as being common, but are not included in other lists.
        /// </para>
        /// <para>
        /// gai1/2: common loanwords, based on the wordfreq file.
        /// </para>
        /// <para>
        /// - nfxx: this is an indicator of frequency-of-use ranking in the
        /// wordfreq file. "xx" is the number of the set of 500 words in which
        /// the entry can be found, with "01" assigned to the first 500, "02"
        /// to the second, and so on. (The entries with news1, ichi1, spec1, spec2
        /// and gai1 values are marked with a "(P)" in the EDICT and EDICT2
        /// files.)
        /// </para>
        /// <para>
        /// The reason both the kanji and reading elements are tagged is because
        /// on occasions a priority is only associated with a particular
        /// kanji/reading pair.
        /// </para>
        /// </summary>
        [XmlElement("ke_pri")]
        public string[] Priorities { get; set; }
    }

    public class JMDictReading
    {
        /// <summary>
        /// <para>
        /// 
        /// </para>
        /// 
        /// </summary>
        [XmlElement("reb")]
        public string Reading { get; set; }

        /// <summary>
        /// <para>
        /// The reading element typically contains the valid readings
        /// of the word(s) in the kanji element using modern kanadzukai.
        /// Where there are multiple reading elements, they will typically be
        /// alternative readings of the kanji element.
        /// </para>
        /// In the absence of a
        /// kanji element, i.e. in the case of a word or phrase written
        /// entirely in kana, these elements will define the entry.
        /// </summary>
        [XmlElement("re_nokanji")]
        public string NoKanji { get; set; }

        /// <summary>
        /// <para>
        /// This element is used to indicate when the reading only applies
        /// to a subset of the keb elements in the entry.
        /// </para>
        /// In its absence, all
        /// readings apply to all kanji elements.The contents of this element
        /// must exactly match those of one of the keb elements.
        /// </summary>
        [XmlElement("re_restr")]
        public string[]? Restrictions { get; set; }

        /// <summary>
        /// General coded information pertaining to the specific reading.
        /// Typically it will be used to indicate some unusual aspect of
        /// the reading.
        /// 
        /// </summary>
        [XmlElement("re_inf")]
        public string[] Information { get; set; }

        /// <summary>
        /// <para>
        /// This and the equivalent ke_pri field are provided to record
        /// information about the relative priority of the entry, and consist
        /// of codes indicating the word appears in various references which
        /// can be taken as an indication of the frequency with which the word
        /// is used.This field is intended for use either by applications which
        /// want to concentrate on entries of a particular priority, or to
        /// generate subset files.
        /// </para>
        /// The current values in this field are:
        /// <para>
        /// - news1/2: appears in the "wordfreq" file compiled by Alexandre Girardi
        /// from the Mainichi Shimbun. (See the Monash ftp archive for a copy.)
        /// Words in the first 12,000 in that file are marked "news1" and words
        /// in the second 12,000 are marked "news2".
        /// </para>
        /// <para>
        /// - ichi1/2: appears in the "Ichimango goi bunruishuu", Senmon Kyouiku
        /// Publishing, Tokyo, 1998.  (The entries marked "ichi2" were
        /// demoted from ichi1 because they were observed to have low
        /// frequencies in the WWW and newspapers.)
        /// </para>
        /// <para>
        /// - spec1 and spec2: a small number of words use this marker when they
        /// are detected as being common, but are not included in other lists.
        /// </para>
        /// <para>
        /// gai1/2: common loanwords, based on the wordfreq file.
        /// </para>
        /// <para>
        /// - nfxx: this is an indicator of frequency-of-use ranking in the
        /// wordfreq file. "xx" is the number of the set of 500 words in which
        /// the entry can be found, with "01" assigned to the first 500, "02"
        /// to the second, and so on. (The entries with news1, ichi1, spec1, spec2
        /// and gai1 values are marked with a "(P)" in the EDICT and EDICT2
        /// files.)
        /// </para>
        /// <para>
        /// The reason both the kanji and reading elements are tagged is because
        /// on occasions a priority is only associated with a particular
        /// kanji/reading pair.
        /// </para>
        /// </summary>
        [XmlElement("re_pri")]
        public string[] Priorities { get; set; }
    }

    /// </summary>
    public class JMDictSource
    {
        /// <summary>
        /// The content of the source item.
        /// </summary>
        [XmlText]
        public string Content { get; set; }

        /// <summary>
        /// <para>
        /// The xml:lang attribute defines the language(s) from which
        /// a loanword is drawn. 
        /// </para>
        /// It will be coded using the three-letter language
        /// code from the ISO 639-2 standard. When absent, the value "eng" (i.e.
        /// English) is the default value. The bibliographic (B) codes are used.
        /// </summary>
        [XmlAttribute("lang")]
        public string Language { get; set; }

        /// <summary>
        /// <para>
        /// The ls_type attribute indicates whether the lsource element
        /// fully or partially describes the source word or phrase of the
        /// loanword.
        /// </para>
        /// If absent, it will have the implied value of "full".
        // Otherwise it will contain "part".
        /// </summary>
        [XmlAttribute("ls_type")]
        public string Type { get; set; }

        /// <summary>
        /// The ls_wasei attribute indicates that the Japanese word
        /// has been constructed from words in the source language, and
        /// not from an actual phrase in that language. Most commonly used to
        /// indicate "waseieigo".
        /// </summary>
        [XmlAttribute("ls_wasei")]
        public string Wasei { get; set; }
    }

    public class JMDictGlossary
    {
        /// <summary>
        /// The content of the glossary item.
        /// </summary>
        [XmlText]
        public string Content { get; set; }

        /// <summary>
        /// <para>
        /// The xml:lang attribute defines the target language of the
        /// gloss.
        /// </para>
        /// It will be coded using the three-letter language code from
        /// the ISO 639 standard. When absent, the value "eng" (i.e. English)
        /// is the default value.
        /// </summary>
        [XmlAttribute("lang")]
        public string Language { get; set; }

        /// <summary>
        /// <para>
        /// The g_gend attribute defines the gender of the gloss (typically
        /// a noun) in the target language.
        /// </para>
        /// When absent, the gender is either
        /// not relevant or has yet to be provided.
        /// </summary>
        [XmlAttribute("g_gend")]
        public string Gender { get; set; }

        /// <summary>
        /// <para>
        /// g_type attribute added in JMDict Rev 1.09
        /// At present the values used are "lit", "fig", "expl" and "tm".
        /// </para>
        /// It is
        /// proposed to add a "descr" value to indicate a gloss which is a
        /// description of the Japanese term rather than a translation or an
        /// explanation of the meaning.
        /// </summary>
        [XmlAttribute("g_type")]
        public string Type { get; set; }
    }

    public class JMDictSense
    {
        /// <summary>
        /// This element, if present, indicate that the sense is restricted
        /// to the lexeme represented by the keb and/or reb.
        /// </summary>
        [XmlElement("stagk")]
        public string[] RestrictedKanji { get; set; }

        /// <summary>
        /// This element, if present, indicate that the sense is restricted
        /// to the lexeme represented by the keb and/or reb.
        /// </summary>
        [XmlElement("stagr")]
        public string[] RestrictedReadings { get; set; }

        /// <summary>
        /// <para>
        /// This element is used to indicate a cross-reference to another
        /// entry with a similar or related meaning or sense.
        /// </para>
        /// The content of
        /// this element is typically a keb or reb element in another entry. In some
        /// cases a keb will be followed by a reb and/or a sense number to provide
        /// a precise target for the cross-reference. Where this happens, a JIS
        /// "centre-dot" (0x2126) is placed between the components of the
        /// cross-reference.
        /// </summary>
        [XmlElement("xref")]
        public string[] References { get; set; }

        /// <summary>
        /// <para>
        /// This element is used to indicate another entry which is an
        /// antonym of the current entry/sense.
        /// </para>
        /// The content of this element
        /// must exactly match that of a keb or reb element in another entry.
        /// </summary>
        [XmlElement("ant")]
        public string[] Antonyms { get; set; }

        /// <summary>
        /// <para>
        /// Part-of-speech information about the entry/sense. Should use
        /// appropriate entity codes.
        /// </para>
        /// In general where there are multiple senses
        /// in an entry, the part-of-speech of an earlier sense will apply to
        /// later senses unless there is a new part-of-speech indicated.
        /// </summary>
        [XmlElement("pos")]
        public string[] PartsOfSpeech { get; set; }

        /// <summary>
        /// <para>
        /// Information about the field of application of the entry/sense.
        /// When absent, general application is implied. 
        /// </para>
        /// Entity coding for specific fields of application.        
        /// </summary>
        [XmlElement("field")]
        public string[] Fields { get; set; }

        /// <summary>
        /// This element is used for other relevant information about
        /// the entry/sense. As with part-of-speech, information will usually
        /// apply to several senses.
        /// </summary>
        [XmlElement("misc")]
        public string[] Misc { get; set; }

        /// <summary>
        /// <para>
        /// This element records the information about the source
        /// language(s) of a loan-word/gairaigo.
        /// </para>
        /// If the source language is other
        /// than English, the language is indicated by the xml:lang attribute.
        /// The element value (if any) is the source word or phrase.
        /// </summary>
        [XmlElement("lsource")]
        public JMDictSource[] SourceLanguages { get; set; }

        /// <summary>
        /// For words specifically associated with regional dialects in
        /// Japanese, the entity code for that dialect, e.g. ksb for Kansaiben.
        /// </summary>
        [XmlElement("dial")]
        public string[] Dialects { get; set; }

        /// <summary>
        /// <para>
        /// The sense-information elements provided for additional
        /// information to be recorded about a sense.
        /// </para>
        /// Typical usage would
        /// be to indicate such things as level of currency of a sense, the
        /// regional variations, etc.
        /// </summary>
        [XmlElement("s_inf")]
        public string[] Information { get; set; }

        /// <summary>
        /// <para>
        /// Within each sense will be one or more "glosses", i.e.
        /// target-language words or phrases which are equivalents to the
        /// Japanese word.
        /// </para>
        /// This element would normally be present, however it
        /// may be omitted in entries which are purely for a cross-reference.
        /// </summary>
        [XmlElement("gloss")]
        public JMDictGlossary[] Glossary { get; set; }

        /// <summary>
        /// Some JMDict entries can contain 0 or more examples
        /// </summary>
        [XmlElement("example")]
        public JMDictExample[] Examples { get; set; }
    }

    public class JMDictExample
    {
        /// <summary>
        /// Each example has a Srce element that indicates the source of the example
        /// the source is typically the  Tatoeba Project
        /// </summary>
        [XmlElement("ex_srce")]
        public JMDictExampleSource ExampleSource { get; set; }

        /// <summary>
        /// The term associated with this example
        /// </summary>
        [XmlElement("ex_text")]
        public string Text { get; set; }

        /// <summary>
        /// Contains the Example sentences
        /// </summary>
        [XmlElement("ex_sent")]
        public JMDictExampleSentence[] Sentences { get; set; }
    }

    public class JMDictExampleSource
    {
        /// <summary>
        /// The id of the example for the source
        /// </summary>
        [XmlText]
        public string Id { get; set; }

        /// <summary>
        /// The source type (i.e. 'tat' for tatoeba)
        /// </summary>
        [XmlAttribute("exsrc_type")]
        public string SourceType { get; set; }
    }

    public class JMDictExampleSentence
    {
        /// <summary>
        /// The language of the example sentence
        /// </summary>
        [XmlAttribute("lang")]
        public string Language { get; set; }

        /// <summary>
        /// The example sentence text
        /// </summary>
        [XmlText]
        public string Text { get; set; }
    }
}
