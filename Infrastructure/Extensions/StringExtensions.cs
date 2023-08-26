using System.Globalization;

namespace Infrastructure.Extensions;

public static class StringExtensions
{
    public static string Reverse(this string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public static string ToTitleCase(this string input)
    {
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
    }

    public static string ToLowerFirstLetter(this string input)
    {
        return input.Substring(0, 1).ToLower() + input.Substring(1);
    }

    public static string ToUpperFirstLetter(this string input)
    {
        return input.Substring(0, 1).ToUpper() + input.Substring(1);
    }

}