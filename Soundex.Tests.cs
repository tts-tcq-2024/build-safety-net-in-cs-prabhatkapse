using System.Globalization;
using System.Xml.Linq;
using Xunit;
using System.Collections.Generic;
using System;

public class SoundexTests
{

    struct MetaData
    {
        public string name { get; private set; }
        public string expectedSoundIndex { get; private set; }

        public MetaData(string _name, string _expectedSoundIndex)
        {
            name = _name;
            expectedSoundIndex = _expectedSoundIndex;
        }
    }

    [Fact]
    public void HandlesString()
    {
        IReadOnlyList<MetaData> testData = new List<MetaData>()
        {      
                            //name       //expectedSoundIndex
            new MetaData( ""        ,         ""    ),
            new MetaData( "A"       ,        "A000" ),
            new MetaData( "Robert"  ,        "R163" ),
            new MetaData( "Rubin"   ,        "R150" ),
            new MetaData( "Ashcroft",        "A261" ),
            new MetaData( "Tymczak" ,        "T522" ),
            new MetaData( "Pfister" ,        "P236" ),
            new MetaData( "Honeyman",        "H550" ),
            new MetaData( "aaBJE1"  ,        "A120" ),

        };

        for (int i = 0; i < testData.Count; i++)
        {
            Assert.Equal(testData[i].expectedSoundIndex, Soundex.GenerateSoundex(testData[i].name));
        }
    }
    
 }

