using System;
using System.Text;
using System.Linq;

public class CodeWars
{
    public static string Encode(string text)
    {
        StringBuilder bits = new StringBuilder();

        foreach (char character in text)
        {
            int asciiValue = (int)character;
            string binary = Convert.ToString(asciiValue, 2).PadLeft(8, '0');

            foreach (char bit in binary)
            {
                bits.Append(new string(bit, 3));
            }
        }

        return bits.ToString();
    }

    public static string Decode(string bits)
    {
        StringBuilder text = new StringBuilder();

        string[] bitGroup = bits.SplitIntoGroups(3);
        var corrected = bitGroup.Select(trio => trio.Count(bit => bit == '0') > 1 ? '0' : '1');
        string[] bytes = String.Join("", corrected).SplitIntoGroups(8);
        string result = "";

        foreach (string bite in bytes)
        {
            int ascii = Convert.ToInt32(bite, 2);
            char ch = (char)ascii;
            result += ch;
        }

        return result;
    }

}

public static class ExtentionMethodExample
{
    public static string[] SplitIntoGroups(this string text, int size)
    {
        if (text.Length % size != 0)
        {
            throw new ArgumentException($"Invalid size ({size}) for text length ({text.Length})");
        }
        string[] groups = new string[text.Length / size];
        int index = 0;

        for (int i = 0; i < text.Length; i += size)
        {
            groups[index++] = text.Substring(i, size);
        }
        return groups;
    }
}