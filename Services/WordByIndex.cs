using emsiZadanie.Models;
using System;

namespace emsiZadanie.Services;

public static class WordByIndex
{

    public static string Search(string text, int index)
    {
        int start = index;
        int end = index;

        while (start >= 1 && !char.IsWhiteSpace(text[start - 1]))
        {
            start--;
        }

        while (end < text.Length && !char.IsWhiteSpace(text[end]))
        {
            end++;
        }

        return text.Substring(start, end - start);
    }

}