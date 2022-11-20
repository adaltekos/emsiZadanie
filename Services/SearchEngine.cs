using emsiZadanie.Models;
using System.Text.RegularExpressions;

namespace emsiZadanie.Services;

public static class SearchEngine
{
//Search Right
    public static string[] SearchRight(SearchQuery searchQuery, SearchProfile searchProfile) 
    {
        string convertedFile = ConvertFileToOneLine.Convert(searchQuery.File!);
        List<string> listOfValues = new List<string>();
        foreach (var phrase in searchProfile.Phrases!)
        {
            string pattern = string.Format(PatternGenerator.Create(searchQuery.Direction!, searchQuery.MaxWordsCount), phrase);
            foreach (Match match in Regex.Matches(convertedFile, pattern, RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase)))
            {
                for(int i = 1; i <= searchQuery.MaxWordsCount; i++) 
                { 
                    listOfValues.Add(match.Groups[i].Value);
                }
            }
        }
        string[] result = listOfValues.ToArray();
        return result;
    }

//Search Left
    public static string[] SearchLeft(SearchQuery searchQuery, SearchProfile searchProfile) 
    {
        string convertedFile = ConvertFileToOneLine.Convert(searchQuery.File!);
        List<string> listOfValues = new List<string>();
        foreach (var phrase in searchProfile.Phrases!)
        {
            string pattern = string.Format(PatternGenerator.Create(searchQuery.Direction!, searchQuery.MaxWordsCount), phrase);
            foreach (Match match in Regex.Matches(convertedFile, pattern, RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase)))
            {
                for (int i = searchQuery.MaxWordsCount; i > 0; i--)
                {
                    listOfValues.Add(match.Groups[i].Value);
                }
            }
        }
        string[] result = listOfValues.ToArray();
        return result;
    }

//Search Top
    public static string[] SearchTop(SearchQuery searchQuery, SearchProfile searchProfile) 
    {
        string[] convertedFileML = ConvertFileToMultipleLines.Convert(searchQuery.File!);
        List<string> listOfValues = new List<string>();
        foreach (var phrase in searchProfile.Phrases!)
        {
            int lineNumber = 0;
            foreach (var line in convertedFileML)
            {
                if (lineNumber > 0)
                {
                    if ((Regex.Match(line, phrase, RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase))).Success)
                    {
                        int index = (Regex.Match(line, string.Format(@"\b{0}\b", phrase), RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase))).Index;
                        string pattern = string.Format(PatternGenerator.Create("right", searchQuery.MaxWordsCount - 1), WordByIndex.Search(convertedFileML[lineNumber - 1], index));
                        foreach (Match match in Regex.Matches(convertedFileML[lineNumber - 1], pattern))
                        {
                            listOfValues.Add(match.Value);
                        }
                    }
                }
                lineNumber++;
            }
        }
        string[] result = listOfValues.ToArray();
        return result;
    }

//Search Bottom
    public static string[] SearchBottom(SearchQuery searchQuery, SearchProfile searchProfile) 
    {
        string[] convertedFileML = ConvertFileToMultipleLines.Convert(searchQuery.File!);
        List<string> listOfValues = new List<string>();
        foreach (var phrase in searchProfile.Phrases!)
        {
            int lineNumber = 0;
            foreach (var line in convertedFileML)
            {
                if (lineNumber < convertedFileML.Length-1)
                {
                    if ((Regex.Match(line, string.Format(@"\b{0}\b", phrase), RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase))).Success)
                    {
                        int index = (Regex.Match(line, phrase, RegexIgnoreCaseOption.Set(searchQuery.IgnoreCase))).Index;
                        string pattern = string.Format(PatternGenerator.Create("right", searchQuery.MaxWordsCount - 1), WordByIndex.Search(convertedFileML[lineNumber + 1], index));
                        foreach (Match match in Regex.Matches(convertedFileML[lineNumber + 1], pattern))
                        {
                            listOfValues.Add(match.Value);
                            listOfValues.Add(pattern);
                        }
                    }
                }
                lineNumber++;
            }
        }
        string[] result = listOfValues.ToArray();
        return result;
    }

}