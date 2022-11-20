using emsiZadanie.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace emsiZadanie.Services;

public static class PatternGenerator
{

    public static string Create(string direction, int maxWordsCount)
    {
        string pattern = @"\b{0}\b";
        if (direction == "left")
        {
            for (int i = 0; i < maxWordsCount; i++) 
            {
                pattern = @"(\S+)\s*" + pattern;
            }
        }
        if (direction == "right") 
        {
            for (int i = 0; i < maxWordsCount; i++)
            {
                pattern = pattern + @"\s*(\S+)";
            }
        }
        
        return pattern;
    }

}