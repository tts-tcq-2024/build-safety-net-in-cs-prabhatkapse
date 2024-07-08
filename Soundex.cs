using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        return SoundIndex(name);
    }

     private static string SoundIndex(string name)
     {
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);
        int count = 1; // To count the number of digits added
        var vowelSeprateSameCode = false;

        for (int i = 1; i < name.Length && count < 4; i++)
        {
            char currentChar = char.ToUpper(name[i]);
            char code = GetSoundexCode(currentChar);

            if (code == 0)
            {
               vowelSeprateSameCode = checkIfVowelSeprateSameCode(name, i, prevCode, currentChar);
               continue;
            }
            else if ((code != prevCode) || (vowelSeprateSameCode))
            {
                soundex.Append(code);
                prevCode = code;
                count++;
                vowelSeprateSameCode = false;
            }
        }

        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
         
        return soundex.ToString();
     }
         
     private static bool currCharIsVowel(char currentChar)
        {
            var vowels = new List<char>() { 'A', 'E', 'I', 'O', 'U' };

            return vowels.Contains(currentChar);
        }


    private static bool checkIfVowelSeprateSameCode(string name, int index, char prevCode, char currentChar)
    {
        return (index + 1 < name.Length) && currCharIsVowel(currentChar) && (GetSoundexCode(name[index + 1]) == prevCode);;
    }

    private static readonly Dictionary<char, char> SoundexCodeMap = new Dictionary<char, char>
    {
        { 'B', '1' }, { 'F', '1' }, { 'P', '1' }, { 'V', '1' },
        { 'C', '2' }, { 'G', '2' }, { 'J', '2' }, { 'K', '2' },
        { 'Q', '2' }, { 'S', '2' }, { 'X', '2' }, { 'Z', '2' },
        { 'D', '3' }, { 'T', '3' },
        { 'L', '4' },
        { 'M', '5' }, { 'N', '5' },
        { 'R', '6' }
    };

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return SoundexCodeMap.TryGetValue(c, out char code) ? code : '0'; // For A, E, I, O, U, H, W, Y
    }
}
