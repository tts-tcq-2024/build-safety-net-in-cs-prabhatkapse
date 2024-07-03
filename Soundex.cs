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
                if (currCharIsVowel(currentChar))
                {
                    vowelSeprateSameCode = checkIfVowelSeprateSameCode(name, i, prevCode);
                    continue;
                }
                else if (checkIfHWSeprateSameCode(name, i, prevCode, currentChar))
                {
                    continue;
                }

                continue;
            }


            if ((code != prevCode) || (vowelSeprateSameCode))
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

            if (vowels.Contains(currentChar))
            {
                return true;
            }
            return false;
        }


    private static bool checkIfVowelSeprateSameCode(string name, int index, char prevCode)
    {
        if (index + 1 < name.Length)
        {
            char nextCode = GetSoundexCode(name[index + 1]);
            if (nextCode == prevCode)
            {
                return true; //code the number twice if separated by a vowel other than H or W
            }
        }
        return false;
    }

    private static bool checkIfHWSeprateSameCode(string name, int index, char prevCode, char currentChar)
    {
        if (currentChar == 'H' || currentChar == 'W')
        {
            if (index + 1 < name.Length)
            {
                char nextCode = GetSoundexCode(name[index + 1]);
                if (nextCode == prevCode)
                {
                    return true; // Skip h or w if it separates two same codes
                }
            }
        }

        return false;
    }

private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        switch (c)
        {
            case 'B':
            case 'F':
            case 'P':
            case 'V':
                return '1';
            case 'C':
            case 'G':
            case 'J':
            case 'K':
            case 'Q':
            case 'S':
            case 'X':
            case 'Z':
                return '2';
            case 'D':
            case 'T':
                return '3';
            case 'L':
                return '4';
            case 'M':
            case 'N':
                return '5';
            case 'R':
                return '6';
            default:
                return '0'; // For A, E, I, O, U, H, W, Y
        }
    }
}
