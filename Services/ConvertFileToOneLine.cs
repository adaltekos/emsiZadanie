using emsiZadanie.Models;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace emsiZadanie.Services;

public static class ConvertFileToOneLine
{

    public static string Convert(IFormFile file) 
    {
        string readContents;
        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            readContents = reader.ReadToEnd();
        }
        readContents = readContents.ReplaceLineEndings(" ");
        return readContents;
    }

}