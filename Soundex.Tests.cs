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
            new MetaData( "",           ""          ),
            new MetaData( "A000",       "A"         ),
            new MetaData( "R163",       "Robert"    ),
            new MetaData( "R150",       "Rubin"     ),
            new MetaData( "A161",       "Ashcroft"  ),
            new MetaData( "T522",       "Tymczak"   ),
            new MetaData( "P236",       "Pfister"   ),
            new MetaData( "H555",       "Honeyman"  ),
            new MetaData( "A120",       "aaBJE1"    ),

        };

        for (int i = 0; i < testData.Count; i++)
        {
            Assert.Equal(testData[i].expectedSoundIndex, Soundex.GenerateSoundex(testData[i].name));
        }
    }
    
 }

