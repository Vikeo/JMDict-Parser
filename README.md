# JMDict-Parser

This is a parser written in Dotnet 7 for parsing the XML files for [JMDict](http://www.edrdg.org/JMDict/j_JMDict.html), [JMnedict](http://www.edrdg.org/enamdict/enamdict_doc.html) and [KANJIDIC2](http://www.edrdg.org/wiki/index.php/KANJIDIC_Project).

## Compatability

This parser is currently compatible with the following versions of the dictionaries:

- JMDict: Rev 1.09
- JMnedict: Rev 1.08
- KANJIDIC2: Version 1.6

Using any newer versions of the dictionaries should still work, but each revision add new features that this parser might not utilize.

## Notes

- This parser might not be compatible with future versions of the dictionaries, as the format of the XML files might change. I will try to keep this package up to date with the latest versions of the dictionaries. If you find any issues with the parser, please contact me.

- Most of the properties of the classes are currently `nullable`, therefore you should check for null before using them. See examples below.

- The dictionary three classes ( `Jmdict`, `Jmnedict` and `Kanjidic` ) have different sets of properties, as the dictionaries have different sets of data.

- The DictParser methods are currently synchronous since the XMLSerializer only can deserialize XML files synchronously.

## Usage examples

You can use the parser by first creating an instance of the `DictParser` class and then calling the `ParseXml` method with the appropriate type and the path to the XML file.

```csharp
var jmdictParser = new DictParser();
var kanjidic2 = jmdictParser.ParseXml<Kanjidic>("path/to/kanjidic2.xml");
```

Then you can either loop through the data:

```csharp
// Loop through each character in the dictionary
foreach (var character in kanjidic2.Characters)
{
    // Make sure everything up to the Readings object are not null using the null-coalescing operator
    if (character?.ReadingMeaning?.ReadingMeaningGroup?.Readings != null)
    {
        // Do something with the data
        foreach (var reading in character.ReadingMeaning.ReadingMeaningGroup.Readings)
        {
            Console.WriteLine(JsonConvert.SerializeObject(reading, Formatting.Indented));
        }
    }
}
```

Or use LINQ to get the data you want:

```csharp
// LINQ expression to get all the readings, english meanings and the kanji character for every character in the dictionary
var readingsMeaningKanji = kanjidic2.Characters
    .Select(c => new
    {
        Kanji = c.Literal,
        Readings = c?.ReadingMeaning?.ReadingMeaningGroup?.Readings,
        Meanings = c?.ReadingMeaning?.ReadingMeaningGroup?.Meanings?.Where(m => m.Language == null) // If the language is null, it means that the meaning is in English
    })
    .Where(rmk => rmk.Readings != null && rmk.Meanings != null);

// Process the data
foreach (var reading in readingsMeaningKanji)
{
    Console.WriteLine(JsonConvert.SerializeObject(reading, Formatting.Indented));
}
```
