using emsiZadanie.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace emsiZadanie.Services;

public static class ConvertFileToMultipleLines
{

    public static string[] Convert(IFormFile file) 
    {
        List<string> fileLines = new List<string>();
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
            fileLines.Add(line);
            }
        }
        string[] result = fileLines.ToArray();
        return result;
    }

}