using emsiZadanie.Models;
using emsiZadanie.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace emsiZadanie.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchQueryController : ControllerBase
{
    public SearchQueryController()
    {
    }

    [HttpPost]
    public IActionResult OnPost([FromQuery] SearchQuery parameters)
    {
        if (parameters.ProfileId < 0 || SearchProfileService.Get(parameters.ProfileId)==null)
        {
            return ValidationProblem("ProfileId must be greater than 0 or profile with that Id does not exist");
        }
        else if ((parameters.Direction != "right") && (parameters.Direction != "left") && parameters.Direction != "top" && parameters.Direction != "bottom") 
        {
            return ValidationProblem("Values for Direction could be only: 'right', 'left', 'top', 'bottom'" + parameters.Direction);
        }
        else if (parameters.MaxWordsCount < 1) 
        {
            return ValidationProblem("MaxWordsCount must be greater than 1");
        }
        else
        {
            string[] searchedResults = SearchQueryService.Search(parameters, SearchProfileService.Get(parameters.ProfileId));
            return Ok(searchedResults);
        }
    }

}