using emsiZadanie.Models;
using emsiZadanie.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System;

namespace emsiZadanie.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchProfileController : ControllerBase
{
    public SearchProfileController()
    {
    }

    [HttpPost]
    public IActionResult Create([Required] List<string> phrases)
    {
        if (phrases.Any(i => String.IsNullOrWhiteSpace(i) == true))
        {
            return ValidationProblem("Phrases cannot be null, empty or white spaced");
        }
        else
        { 
            SearchProfileService.Add(phrases);
            return CreatedAtAction(nameof(Create), phrases);
        }
    }

}