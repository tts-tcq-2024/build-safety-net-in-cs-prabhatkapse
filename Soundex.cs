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

        StringBuilder soundex = new StringBuilder();

        ProcessInitialChar(name, out soundex);

        soundex.Append(ProcessRemainingChar(name.ToUpper()));

        return soundex.ToString();
    }
    private static void ProcessInitialChar(string name, out StringBuilder soundex)
    {
        soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
    }

    private static string ProcessRemainingChar(string name)
    {
        StringBuilder soundex = new StringBuilder();
        char prevCode = GetSoundexCode(name[0]);
        var vowelSeprateSameCode = false;

        for (int i = 1; i < name.Length && soundex.Length < 3; i++)
        {
            char currentChar = name[i];
            char code = GetSoundexCode(currentChar);

            if (code == 0)
            {
                vowelSeprateSameCode = checkIfVowelSeprateSameCode(name, i, prevCode, currentChar);
                continue;
            }
            else if (ShouldAppendCode(code, prevCode, vowelSeprateSameCode))
            {
                soundex.Append(code);
                prevCode = code;
                vowelSeprateSameCode = false;
            }
                     
        }
        return PadSoundex(soundex);
    }

    private static bool ShouldAppendCode(char code, char prevCode, bool vowelSeprateSameCode)
    {
        return (code != prevCode) || (vowelSeprateSameCode);
    }

    private static string PadSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 3)
        {
            soundex.Append(0);
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
        return (index + 1 < name.Length) && currCharIsVowel(currentChar) && (GetSoundexCode(name[index + 1]) == prevCode); ;
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
