using System.Xml.Serialization;

namespace JMDict
{
    /// <summary>
    /// This is the DTD of the XML-format kanji file combining information from
    /// the KANJIDIC and KANJD212 files.
    /// <para>
    /// It is intended to be largely self-
    /// documenting, with each field being accompanied by an explanatory
    /// comment.
    /// </para>
    /// </summary>
    [Serializable, XmlRoot("kanjidic2")]
    public class Kanjidic : IDict
    {
        /// <summary>
        /// The single header element will contain identification information
        /// about the version of the file
        /// </summary>
        [XmlElement("header")]
        public KanjidicHeader? Header { get; set; }

        /// <summary>
        /// The character element contains information about a single kanji
        /// character.
        /// </summary>
        [XmlElement("character")]
        public KanjidicCharacter[]? Characters { get; set; }
    }

    /// <summary>
    /// The single header element will contain identification information
    /// about the version of the file
    /// </summary>
    public class KanjidicHeader
    {
        /// <summary>
        /// This field denotes the version of kanjidic2 structure, as more
        /// than one version may exist.
        /// </summary>
        [XmlElement("file_version")]
        public string? FileVersion { get; set; }

        /// <summary>
        /// The version of the file, in the format YYYY-NN, where NN will be
        /// a number starting with 01 for the first version released in a
        /// calendar year, then increasing for each version in that year.
        /// </summary>
        [XmlElement("database_version")]
        public string? DatabaseVersion { get; set; }

        /// <summary>
        /// The date the file was created in international format (YYYY-MM-DD).
        /// </summary>
        [XmlElement("date_of_creation")]
        public string? DateOfCreation { get; set; }
    }

    /// <summary>
    /// The character element contains information about a single kanji
    /// character.
    /// </summary>
    public class KanjidicCharacter
    {
        /// <summary>
        /// The character itself in UTF8 coding.
        /// </summary>
        [XmlElement("literal")]
        public string? Literal { get; set; }

        /// <summary>
        /// The codepoint element states the code of the character in the various 
        /// character set standards.
        /// </summary>
        [XmlElement("codepoint")]
        public KanjidicCodePoint? Codepoint { get; set; }

        /// <summary>
        /// The radical element.
        /// </summary>
        [XmlElement("radical")]
        public KanjidicRadical? Radical { get; set; }

        /// <summary>
        /// Element containing miscellaneous information about the kanji.
        /// </summary>
        [XmlElement("misc")]
        public KanjidicMisc? Misc { get; set; }

        /// <summary>
        /// This element contains the index numbers and similar unstructured
        /// information such as page numbers in a number of published dictionaries,
        /// and instructional books on kanji.
        /// </summary>
        [XmlElement("dic_number")]
        public KanjidicDicNumber[]? DictionaryNumbers { get; set; }

        /// <summary>
        /// These codes contain information relating to the glyph, and can be used
        /// for finding a required kanji.
        /// <para>
        /// The type of code is defined by the qc_type attribute.
        /// </para>
        /// </summary>
        [XmlElement("query_code")]
        public KanjidicQueryCode? QueryCode { get; set; }



        /// <summary>
        /// The readings for the kanji in several languages, and the meanings, also
        /// in several languages.
        /// <para>
        /// The readings and meanings are grouped to enable
        /// the handling of the situation where the meaning is differentiated by
        /// reading. [T1] 
        /// </para>
        /// </summary>
        [XmlElement("reading_meaning")]
        public KanjidicReadingMeaning? ReadingMeaning { get; set; }
    }

    /// <summary>
    /// The codepoint element states the code of the character in the various 
    /// character set standards.
    /// </summary>
    public class KanjidicCodePoint
    {
        /// <summary>
        /// The cp_value contains the codepoint of the character in a particular
        /// standard.
        ///<para>
        /// The standard will be identified in the cp_type attribute.
        /// </para>
        /// </summary>
        [XmlElement("cp_value")]
        public KanjidicCodePointValue[]? Values { get; set; }
    }

    /// <summary>
    /// The cp_value contains the codepoint of the character in a particular
    /// standard.
    ///<para>
    /// The standard will be identified in the cp_type attribute.
    /// </para>
    /// </summary>
    public class KanjidicCodePointValue
    {
        /// <summary>
        /// The cp_type attribute states the coding standard applying to the
        /// element.The values assigned so far are:
        /// <para>jis208 - JIS X 0208-1997 - kuten coding(nn-nn)</para>
        /// <para>jis212 - JIS X 0212-1990 - kuten coding(nn-nn)</para>
        /// <para>jis213 - JIS X 0213-2000 - kuten coding(p-nn-nn)</para>
        /// <para>ucs - Unicode 4.0 - hex coding(4 or 5 hexadecimal digits)</para>
        /// </summary>
        [XmlAttribute("cp_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value in the type of coding standard.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }
    }

    /// <summary>
    /// The radical number, in the range 1 to 214. The particular
    /// classification type is stated in the rad_type attribute.
    /// </summary>
    public class KanjidicRadical
    {
        /// <summary>
        /// The radical number, in the range 1 to 214. The particular
        /// classification type is stated in the rad_type attribute.
        /// </summary>
        [XmlElement("rad_value")]
        public KanjidicRadicalValue[]? Values { get; set; }
    }

    /// <summary>
    /// The radical number, in the range 1 to 214. The particular
    /// classification type is stated in the rad_type attribute.
    /// </summary>
    public class KanjidicRadicalValue
    {
        /// <summary>
        /// The rad_type attribute states the type of radical classification.
        /// <para>classical - based on the system first used in the KangXi Zidian.
        /// The Shibano "JIS Kanwa Jiten" is used as the reference source. </para> 
        /// <para> nelson_c - as used in the Nelson "Modern Japanese-English Character Dictionary" 
        ///(i.e. the Classic, not the New Nelson).
        /// This will only be used where Nelson reclassified the kanji. </para>
        /// </summary>
        [XmlAttribute("rad_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value according to the type of radical classification.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }
    }

    /// <summary>
    /// Element containing miscellaneous information about the kanji.
    /// </summary>
    public class KanjidicMisc
    {
        /// <summary>
        /// The kanji grade level. 1 through 6 indicates a Kyouiku kanji
        /// and the grade in which the kanji is taught in Japanese schools. 
        /// <para>
        /// 8 indicates it is one of the remaining Jouyou Kanji to be learned
        /// in junior high school. 9 indicates it is a Jinmeiyou (for use
        /// in names) kanji which in addition to the Jouyou kanji are approved 
        /// for use in family name registers and other official documents. 10
        /// also indicates a Jinmeiyou kanji which is a variant of a
        /// Jouyou kanji. [G]
        /// </para>
        /// </summary>
        [XmlElement("grade")]
        public string? Grade { get; set; }

        /// <summary>
        /// The stroke count of the kanji, including the radical.
        /// <para>
        /// If more than
        /// one, the first is considered the accepted count, while subsequent ones
        /// are common miscounts. (See Appendix E. of the KANJIDIC documentation
        /// for some of the rules applied when counting strokes in some of the
        /// radicals.) [S]
        /// </para>
        /// </summary>
        [XmlElement("stroke_count")]
        public string[]? StrokeCounts { get; set; }

        /// <summary>
        /// Either a cross-reference code to another kanji, usually regarded as a
        /// variant, or an alternative indexing code for the current kanji.
        /// <para>
        /// The type of variant is given in the var_type attribute. 
        /// </para>
        /// </summary>
        [XmlElement("variant")]
        public KanjidicVariant[]? Variants { get; set; }

        /// <summary>
        /// A frequency-of-use ranking. The 2,500 most-used characters have a 
        /// ranking; those characters that lack this field are not ranked.
        /// <para>
        /// The frequency is a number from 1 to 2,500 that expresses the relative
        /// frequency of occurrence of a character in modern Japanese. This is
        /// based on a survey in newspapers, so it is biassed towards kanji
        /// used in newspaper articles. The discrimination between the less
        /// frequently used kanji is not strong. (Actually there are 2,501
        /// kanji ranked as there was a tie.)
        /// </para>
        /// </summary>
        [XmlElement("freq")]
        public string? Frequency { get; set; }

        /// <summary>
        /// When the kanji is itself a radical and has a name, this element
        /// contains the name(in hiragana.) [T2]
        /// </summary>
        [XmlElement("rad_name")]
        public string[]? RadicalName { get; set; }

        /// <summary>
        /// The (former) Japanese Language Proficiency test level for this kanji.
        /// Values range from 1 (most advanced) to 4 (most elementary). 
        /// <para>
        /// This field does not appear for kanji that were not required for any JLPT level.
        /// </para>
        /// <para>
        /// Note that the JLPT test levels changed in 2010, with a new 5-level
        /// system(N1 to N5) being introduced. No official kanji lists are
        /// available for the new levels. The new levels are regarded as
        /// being similar to the old levels except that the old level 2 is
        /// now divided between N2 and N3.
        /// </para>
        /// </summary>
        [XmlElement("jlpt")]
        public string? JlptLevel { get; set; }
    }

    /// <summary>
    /// Either a cross-reference code to another kanji, usually regarded as a
    /// variant, or an alternative indexing code for the current kanji.
    /// <para>
    /// The type of variant is given in the var_type attribute. 
    /// </para>
    /// </summary>
    public class KanjidicVariant
    {
        /// <summary>
        /// The var_type attribute indicates the type of variant code. The current
        /// values are: 
        /// <para>jis208 - in JIS X 0208 - kuten coding</para>
        /// <para>jis212 - in JIS X 0212 - kuten coding</para>
        /// <para>jis213 - in JIS X 0213 - kuten coding</para>
        /// <para>(most of the above relate to "shinjitai/kyuujitai" alternative character glyphs)</para>
        /// <para>deroo - De Roo number - numeric</para>
        /// <para>njecd - Halpern NJECD index number - numeric</para>
        /// <para>s_h - The Kanji Dictionary (Spahn and Hadamitzky) - descriptor</para>
        /// <para>nelson_c - "Classic" Nelson - numeric</para>
        /// <para>oneill - Japanese Names (O'Neill) - numeric</para>
        /// <para>ucs - Unicode codepoint- hex</para>
        /// </summary>
        [XmlAttribute("var_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value according to the type of variant code.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }
    }

    /// <summary>
    /// This element contains the index numbers and similar unstructured
    /// information such as page numbers in a number of published dictionaries,
    /// and instructional books on kanji.
    /// </summary>
    public class KanjidicDicNumber
    {
        /// <summary>
        /// Each dic_ref contains an index number. The particular dictionary,
        /// etc. is defined by the dr_type attribute.
        /// </summary>
        [XmlElement("dic_ref")]
        public KanjidicDicRef[]? References { get; set; }
    }

    /// <summary>
    /// Each dic_ref contains an index number. The particular dictionary,
    /// etc. is defined by the dr_type attribute.
    /// </summary>
    public class KanjidicDicRef
    {
        /// <summary>
        /// The dr_type defines the dictionary or reference book, etc. to which
        /// dic_ref element applies.The initial allocation is:
        /// <para>nelson_c - "Modern Reader's Japanese-English Character Dictionary",  
        /// edited by Andrew Nelson(now published as the "Classic" Nelson).</para>
        /// <para>nelson_n - "The New Nelson Japanese-English Character Dictionary", 
        /// edited by John Haig.</para>
        /// <para>halpern_njecd - "New Japanese-English Character Dictionary", 
        /// edited by Jack Halpern.</para>
        /// <para>halpern_kkd - "Kodansha Kanji Dictionary", (2nd Ed. of the NJECD)
        /// edited by Jack Halpern.</para>
        /// <para>halpern_kkld - "Kanji Learners Dictionary" (Kodansha) edited by 
        /// Jack Halpern.</para>
        /// <para>halpern_kkld_2ed - "Kanji Learners Dictionary" (Kodansha), 2nd edition
        /// (2013) edited by Jack Halpern.</para>
        /// <para>heisig - "Remembering The  Kanji"  by  James Heisig.</para>
        /// <para> heisig6 - "Remembering The  Kanji, Sixth Ed."  by  James Heisig.</para>
        /// <para> gakken - "A  New Dictionary of Kanji Usage" (Gakken)</para>
        /// <para>oneill_names - "Japanese Names", by P.G. O'Neill. </para>
        /// <para>oneill_kk - "Essential Kanji" by P.G. O'Neill.</para>
        /// <para>moro - "Daikanwajiten" compiled by Morohashi. For some kanji two
        /// additional attributes are used: m_vol:  the volume of the
        /// dictionary in which the kanji is found, and m_page: the page number in the volume.</para>
        /// <para>henshall - "A Guide To Remembering Japanese Characters" by
        /// Kenneth G.  Henshall.</para>
        /// <para>sh_kk - "Kanji and Kana" by Spahn and Hadamitzky.</para>
        /// <para>sh_kk2 - "Kanji and Kana" by Spahn and Hadamitzky (2011 edition).</para>
        /// <para>sakade - "A Guide To Reading and Writing Japanese" edited by
        /// Florence Sakade.</para>
        /// <para>jf_cards - Japanese Kanji Flashcards, by Max Hodges and
        /// Tomoko Okazaki. (Series 1)</para>
        /// <para>henshall3 - "A Guide To Reading and Writing Japanese" 3rd
        /// edition, edited by Henshall, Seeley and De Groot.</para>
        /// <para>tutt_cards - Tuttle Kanji Cards, compiled by Alexander Kask.</para>
        /// <para>crowley - "The Kanji Way to Japanese Language Power" by
        /// Dale Crowley.</para>
        /// <para>kanji_in_context - "Kanji in Context" by Nishiguchi and Kono.</para>
        /// <para>busy_people - "Japanese For Busy People" vols I-III, published
        /// by the AJLT.The codes are the volume.chapter.</para>
        /// <para>kodansha_compact - the "Kodansha Compact Kanji Guide".</para>
        /// <para>maniette - codes from Yves Maniette's "Les Kanjis dans la tete" French adaptation of Heisig.</para>
        /// </summary>
        [XmlAttribute("dr_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value according to the type of dictionary reference.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }

        /// <summary>
        /// If the reference type is moro, this attribute is used.
        /// <para>
        /// Specific for the moro type. 
        /// The volume of the dictionary in which the kanji is found.
        /// </para>
        ///</summary>
        [XmlAttribute("m_vol")]
        public string? Volume { get; set; }

        /// <summary>
        /// If the reference type is moro, this attribute is used.
        /// <para>
        /// The page number in the volume.
        /// </para>
        ///</summary>
        [XmlAttribute("m_page")]
        public string? Page { get; set; }
    }

    /// <summary>
    /// These codes contain information relating to the glyph, and can be used
    /// for finding a required kanji.
    /// <para>
    /// The type of code is defined by the qc_type attribute.
    /// </para>
    /// </summary>
    public class KanjidicQueryCode
    {
        /// <summary>
        /// The q_code contains the actual query-code value, according to the
        /// qc_type attribute.
        /// </summary>
        [XmlElement("q_code")]
        public QueryCode[]? QueryCodes { get; set; }
    }

    /// <summary>
    /// The q_code contains the actual query-code value, according to the
    /// qc_type attribute.
    /// </summary>
    public class QueryCode
    {


        /// <summary>
        /// The qc_type attribute defines the type of query code.The current values
        ///   are:
        /// <para>skip -  Halpern's SKIP (System  of  Kanji  Indexing  by  Patterns)
        /// code.The format is n-nn-nn.See the KANJIDIC documentation
        /// for  a description of the code and restrictions on  the
        /// commercial  use of this data. [P] There are also
        /// a number of misclassification codes, indicated by the
        /// "skip_misclass" attribute.</para>
        /// <para>sh_desc - the descriptor codes for The Kanji Dictionary(Tuttle
        /// 	1996) by Spahn and Hadamitzky.They are in the form nxnn.n,
        ///     e.g.  3k11.2, where the  kanji has 3 strokes in the
        ///     identifying radical, it is radical "k" in the SH
        ///     classification system, there are 11 other strokes, and it is
        ///     the 2nd kanji in the 3k11 sequence. (I am very grateful to
        ///     Mark Spahn for providing the list of these descriptor codes
        /// 	for the kanji in this file.) [I]</para>
        /// <para>four_corner - the "Four Corner" code for the kanji.This is a code
        /// 	invented by Wang Chen in 1928. See the KANJIDIC documentation
        /// 	for  an overview of the Four Corner System. [Q]</para>
        /// <para>deroo - the codes developed by the late Father Joseph De Roo, and
        /// 	published in his book "2001 Kanji" (Bonjinsha). Fr De Roo
        /// 	gave his permission for these codes to be included. [DR]</para>
        /// <para>misclass - a possible misclassification of the kanji according
        /// 	to one of the code types. (See the "Z" codes in the KANJIDIC
        /// 	documentation for more details.)</para>
        /// </summary>
        [XmlAttribute("qc_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value according to the type of query code.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }

        /// <summary>
        /// The values of this attribute indicate the type if
        /// misclassification:
        /// <para> posn - a mistake in the division of the kanji </para>
        /// <para> stroke_count - a mistake in the number of strokes </para>
        /// <para> stroke_and_posn - mistakes in both division and strokes </para>
        /// <para> stroke_diff - ambiguous stroke counts depending on glyph </para>
        /// </summary>
        [XmlAttribute("skip_misclass")]
        public string? Misclassification { get; set; }
    }

    /// <summary>
    /// The readings for the kanji in several languages, and the meanings, also
    /// in several languages.
    /// <para>
    /// The readings and meanings are grouped to enable
    /// the handling of the situation where the meaning is differentiated by
    /// reading. [T1] 
    /// </para>
    /// </summary>
    public class KanjidicReadingMeaning
    {
        /// <summary>
        /// The rmgroup element contains the reading and meaning
        /// information for the kanji in different languages.
        /// </summary>
        [XmlElement("rmgroup")]
        public ReadingMeaningGroup[]? ReadingMeaningGroups { get; set; }

        /// <summary>
        /// Japanese readings that are now only associated with names.
        /// </summary>
        [XmlElement("nanori")]
        public string[]? Nanori { get; set; }
    }

    /// <summary>
    /// The rmgroup element contains the reading and meaning
    /// information for the kanji in different languages.
    /// </summary>
    public class ReadingMeaningGroup
    {
        /// <summary>
        /// The reading element contains the reading or pronunciation
        /// of the kanji.
        /// </summary>
        [XmlElement("reading")]
        public KanjidicReading[]? Readings { get; set; }

        /// <summary>
        /// The meaning associated with the kanji.
        /// </summary>
        [XmlElement("meaning")]
        public KanjidicMeaning[]? Meanings { get; set; }
    }

    /// <summary>
    /// The reading element contains the reading or pronunciation
    /// of the kanji.
    /// </summary>
    public class KanjidicReading
    {
        /// <summary>
        /// The r_type attribute defines the type of reading in the reading
        /// element.The current values are:
        /// <para>pinyin - the modern PinYin romanization of the Chinese reading 
        /// of the kanji.The tones are represented by a concluding
        ///   digit. [Y]</para>
        /// <para>korean_r - the romanized form of the Korean reading(s) of the 
        /// kanji.The readings are in the (Republic of Korea) Ministry
        ///   of Education style of romanization. [W]</para>
        /// <para>korean_h - the Korean reading(s) of the kanji in hangul.</para>
        /// <para>vietnam - the Vietnamese readings supplied by Minh Chau Pham.</para>
        /// <para>ja_on - the "on" Japanese reading of the kanji, in katakana. 
        /// Another attribute r_status, if present, will indicate with
        ///   a value of "jy" whether the reading is approved for a
        /// "Jouyou kanji". (The r_status attribute is not currently used.)
        /// A further attribute on_type, if present,  will indicate with
        /// a value of kan, go, tou or kan'you the type of on-reading.
        /// (The on_type attribute is not currently used.)</para>
        /// <para>ja_kun - the "kun" Japanese reading of the kanji, usually in 
        /// hiragana.
        ///   Where relevant the okurigana is also included separated by a 
        /// ".". Readings associated with prefixes and suffixes are
        ///   marked with a "-". A second attribute r_status, if present, 
        /// will indicate with a value of "jy" whether the reading is 
        /// approved for a "Jouyou kanji". (The r_status attribute is 
        /// not currently used.)</para>
        /// </summary>
        [XmlAttribute("r_type")]
        public string? Type { get; set; }

        /// <summary>
        /// The value of the reading element according to the type of reading.
        /// </summary>
        [XmlText]
        public string? Value { get; set; }

        /// <summary>
        /// If present, will indicate with
        /// a value of kan, go, tou or kan'you the type of on-reading.
        /// <para>(The on_type attribute is not currently used.)</para>
        /// </summary>
        [XmlAttribute("on_type")]
        public string? OnType { get; set; }

        /// <summary>
        /// if present, will indicate with
        /// a value of "jy" whether the reading is approved for a
        /// "Jouyou kanji". 
        /// <para>(The r_status attribute is not currently used.)</para>
        /// </summary>
        [XmlAttribute("r_status")]
        public string? JouyouStatus { get; set; }
    }

    /// <summary>
    /// The meaning associated with the kanji.
    /// </summary>
    public class KanjidicMeaning
    {
        /// <summary>
        /// The meaning associated with the kanji.
        /// </summary>
        [XmlText]
        public string? Meaning { get; set; }

        /// <summary>
        /// The m_lang attribute defines the target language of the meaning. It 
        /// will be coded using the two-letter language code from the ISO 639-1 
        /// standard.
        /// <para>When absent, the value "en" (i.e.English) is implied. [{}] </para>'
        /// </summary>
        [XmlAttribute("m_lang")]
        public string? Language { get; set; }
    }
}
