using emsiZadanie.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration.CommandLine;
using System.Diagnostics.Tracing;
using System.Text;
using System.Text.RegularExpressions;

namespace emsiZadanie.Services;

public static class SearchQueryService
{

    public static string[] Search(SearchQuery searchQuery, SearchProfile searchProfile) 
    { 
        switch (searchQuery.Direction)
        {
            case "right":
                string[] rightResults = SearchEngine.SearchRight(searchQuery, searchProfile);
                return rightResults;

            case "left":
                string[] leftResults = SearchEngine.SearchLeft(searchQuery, searchProfile);
                return leftResults;

            case "top":
                string[] topResults = SearchEngine.SearchTop(searchQuery, searchProfile);
                return topResults;

            case "bottom":
                string[] bottomResults = SearchEngine.SearchBottom(searchQuery, searchProfile);
                return bottomResults;
            default:
                return new[] {"",""};
        }
        
    }
}